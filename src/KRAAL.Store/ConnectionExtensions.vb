Imports System.Runtime.CompilerServices
Imports MySqlConnector

Friend Module ConnectionExtensions
    <Extension>
    Function GetList(Of T)(
                          connection As MySqlConnection,
                          viewName As String,
                          columnNames As IEnumerable(Of String),
                          filters As IEnumerable(Of (Column As String, Value As Object)),
                          order As String,
                          callback As Func(Of MySqlDataReader, T)) As IEnumerable(Of T)
        Dim result As New List(Of T)
        Using command As New MySqlCommand($"
SELECT 
    {String.Join(",", columnNames)} 
FROM 
    {viewName}{If(filters.Any, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))}
", String.Empty)}
ORDER BY 
    {order};", connection)
            For Each f In filters
                command.Parameters.AddWithValue($"@{f.Column}", f.Value)
            Next
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(callback(reader))
                End While
            End Using
        End Using
        Return result
    End Function

    <Extension>
    Function GetCount(
                     connection As MySqlConnection,
                     viewName As String,
                     filters As IEnumerable(Of (Column As String, Value As Object))) As Integer
        Using command As New MySqlCommand($"
SELECT
    COUNT(1)
FROM
    {viewName}{If(filters.Any, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))}
", String.Empty)}", connection)
            For Each f In filters
                command.Parameters.AddWithValue($"@{f.Column}", f.Value)
            Next
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
End Module
