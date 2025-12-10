Imports System.Runtime.CompilerServices
Imports MySqlConnector

Friend Module ConnectionExtensions
    <Extension>
    Friend Function GetList(Of T)(
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
            ApplyFilters(filters, command)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(callback(reader))
                End While
            End Using
        End Using
        Return result
    End Function

    Private Sub ApplyFilters(filters As IEnumerable(Of (Column As String, Value As Object)), command As MySqlCommand)
        For Each f In filters
            command.Parameters.AddWithValue($"@{f.Column}", f.Value)
        Next
    End Sub

    <Extension>
    Friend Function GetCount(
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
            ApplyFilters(filters, command)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Friend Function Create(connection As MySqlConnection, viewName As String, values As IEnumerable(Of (Column As String, Value As Object)), result As String) As Object
        Using command As New MySqlCommand($"
INSERT INTO 
    {viewName}
        ({String.Join(",", values.Select(Function(x) x.Column))}) 
VALUES 
    ({String.Join(",", values.Select(Function(x) $"@{x.Column}"))}) 
RETURNING 
    {result};", connection)
            ApplyFilters(values, command)
            Return command.ExecuteScalar
        End Using
    End Function
    <Extension>
    Friend Sub Delete(connection As MySqlConnection, viewName As String, filters As IEnumerable(Of (Column As String, Value As Object)))
        Using command As New MySqlCommand($"DELETE FROM {viewName}{If(filters.Any, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))}
", String.Empty)};", connection)
            ApplyFilters(filters, command)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module

