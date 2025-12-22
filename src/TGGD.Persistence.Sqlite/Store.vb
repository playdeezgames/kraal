Imports Microsoft.Data.Sqlite

Public Class Store
    Implements IStore, IDisposable
    Private Const SCAFFOLD_DB_FILENAME = "scaffold_db.sql"

    Private ReadOnly connection As SqliteConnection
    Private disposedValue As Boolean

    Public Sub New()
        connection = New SqliteConnection("Data Source=:memory:;")
        connection.Open()
        Using command As New SqliteCommand(System.IO.File.ReadAllText(SCAFFOLD_DB_FILENAME), connection)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function GetCount(
                            viewName As String,
                            ParamArray filters() As (Column As String, Value As Object)) As Integer Implements IStore.GetCount
        Using command As New SqliteCommand($"
SELECT 
    COUNT(1) 
FROM 
    {viewName}{If(filters.Length > 0, $"
WHERE {String.Join(" AND ", filters.Select(Function(x) $"{x.Column}=@Filter{x.Column}"))}", "")};", connection)
            For Each f In filters
                command.Parameters.AddWithValue($"@Filter{f.Column}", f.Value)
            Next
            Return CInt(command.ExecuteScalar())
        End Using
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                connection.Close()
                connection.Dispose()
            End If
            disposedValue = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function Create(
                          viewName As String,
                          columnValues As IEnumerable(Of (Column As String, Value As Object)),
                          resultColumn As String) As Object Implements IStore.Create
        Using command As New SqliteCommand($"
INSERT INTO 
    {viewName}
        (
            {String.Join(",", columnValues.Select(Function(x) x.Column))}
        ) 
VALUES 
    (
        {String.Join(",", columnValues.Select(Function(x) $"@{x.Column}"))}
    ) 
RETURNING 
    {resultColumn};", connection)
            For Each columnValue In columnValues
                command.Parameters.AddWithValue($"@{columnValue.Column}", columnValue.Value)
            Next
            Return command.ExecuteScalar()
        End Using
    End Function

    Public Function GetColumnValue(
                                  viewName As String,
                                  columnName As String,
                                  ParamArray filters() As (Column As String, Value As Object)) As Object Implements IStore.GetColumnValue
        Using command As New SqliteCommand($"
SELECT 
    {columnName} 
FROM 
    {viewName}{If(filters.Length > 0, $"
WHERE {String.Join(" AND ", filters.Select(Function(x) $"{x.Column}=@Filter{x.Column}"))}", "")};", connection)
            For Each f In filters
                command.Parameters.AddWithValue($"@Filter{f.Column}", f.Value)
            Next
            Return command.ExecuteScalar()
        End Using
    End Function

    Public Sub SetColumnValue(
                             viewName As String,
                             columnValue As (Column As String, Value As Object),
                             ParamArray filters() As (Column As String, Value As Object)) Implements IStore.SetColumnValue
        Using command As New SqliteCommand($"
UPDATE
    {viewName} 
SET 
    {columnValue.Column}=@New{columnValue.Column}{If(filters.Length > 0, $"
WHERE {String.Join(" AND ", filters.Select(Function(x) $"{x.Column}=@Filter{x.Column}"))}", "")};", connection)
            command.Parameters.AddWithValue($"New{columnValue.Column}", columnValue.Value)
            For Each f In filters
                command.Parameters.AddWithValue($"@Filter{f.Column}", f.Value)
            Next
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Delete(
                     viewName As String,
                     ParamArray filters() As (Column As String, Value As Object)) Implements IStore.Delete
        Using command As New SqliteCommand($"DELETE FROM {viewName}{If(filters.Length > 0, $"
WHERE {String.Join(" AND ", filters.Select(Function(x) $"{x.Column}=@Filter{x.Column}"))}", "")};", connection)
            For Each f In filters
                command.Parameters.AddWithValue($"@Filter{f.Column}", f.Value)
            Next
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Export(filename As String) Implements IStore.Export
        Using destinationConnection = New SqliteConnection($"Data Source={filename};")
            destinationConnection.Open()
            connection.BackupDatabase(destinationConnection)
        End Using
    End Sub

    Public Sub Import(filename As String) Implements IStore.Import
        Using sourceConnection = New SqliteConnection($"Data Source={filename};")
            sourceConnection.Open()
            sourceConnection.BackupDatabase(connection)
        End Using
    End Sub

    Public Function GetRecords(Of TResult)(
                                          viewName As String,
                                          columnNames As IEnumerable(Of String),
                                          filters As IEnumerable(Of (Column As String, Compare As Compare, Value As Object)), converter As Func(Of IRecord, TResult)) As IEnumerable(Of TResult) Implements IStore.GetRecords
        Dim result As New List(Of TResult)
        Using command As New SqliteCommand($"SELECT {String.Join(",", columnNames)} FROM {viewName}{If(filters.Count > 0, $"
WHERE {String.Join(" AND ", filters.Select(Function(x) $"{x.Column}{ToOperator(x.Compare)}@Filter{x.Column}"))}", "")};", connection)
            For Each f In filters
                command.Parameters.AddWithValue($"@Filter{f.Column}", f.Value)
            Next
            Using reader = command.ExecuteReader
                Dim record As IRecord = New Record(reader)
                While reader.Read
                    result.Add(converter(record))
                End While
            End Using
        End Using
        Return result
    End Function

    Private Shared Function ToOperator(compare As Compare) As String
        Select Case compare
            Case Compare.EQ
                Return "="
            Case Compare.LE
                Return "<="
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Class
