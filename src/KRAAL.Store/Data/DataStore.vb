Imports MySqlConnector

Public Class DataStore
    Implements IDataStore
    Private connection As MySqlConnection

    Public ReadOnly Property Profiles As IProfileStore Implements IDataStore.Profiles
        Get
            Return New ProfileStore(connection)
        End Get
    End Property

    Public ReadOnly Property Factions As IFactionStore Implements IDataStore.Factions
        Get
            Return New FactionStore(connection)
        End Get
    End Property

    Public ReadOnly Property Units As IUnitStore Implements IDataStore.Units
        Get
            Return New UnitStore(connection)
        End Get
    End Property

    Public ReadOnly Property Buildings As IBuildingStore Implements IDataStore.Buildings
        Get
            Return New BuildingStore(connection)
        End Get
    End Property

    Public ReadOnly Property Housings As IHousingStore Implements IDataStore.Housings
        Get
            Return New HousingStore(connection)
        End Get
    End Property

    Public Sub Open(connectionString As String) Implements IDataStore.Open
        connection = New MySqlConnection(connectionString)
        connection.Open()
    End Sub

    Public Sub Close() Implements IDataStore.Close
        connection.Close()
        connection = Nothing
    End Sub

    Public Function GetList(Of T)(
                                 viewName As String,
                                 columnNames As IEnumerable(Of String),
                                 filters As IEnumerable(Of (Column As String, Value As Object)),
                                 order As String,
                                 callback As Func(Of IStoreResult, T)) As IEnumerable(Of T) Implements IDataStore.GetList
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
            ApplyFilters(filters, command, "")
            Using reader = command.ExecuteReader
                Dim storeResult As IStoreResult = New StoreResult(reader)
                While reader.Read
                    result.Add(callback(storeResult))
                End While
            End Using
        End Using
        Return result
    End Function

    Private Shared Sub ApplyFilters(
                            filters As IEnumerable(Of (Column As String, Value As Object)),
                            command As MySqlCommand, prefix As String)
        For Each f In filters
            command.Parameters.AddWithValue($"@{prefix}{f.Column}", f.Value)
        Next
    End Sub

    Public Function GetCount(viewName As String, filters As IEnumerable(Of (Column As String, Value As Object))) As Integer Implements IDataStore.GetCount
        Using command As New MySqlCommand($"
SELECT
    COUNT(1)
FROM
    {viewName}{If(filters.Any, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))}
", String.Empty)}", connection)
            ApplyFilters(filters, command, "")
            Return CInt(command.ExecuteScalar)
        End Using
    End Function

    Public Function GetColumnValue(viewName As String, columnName As String, ParamArray filters() As (Column As String, Value As Object)) As Object Implements IDataStore.GetColumnValue
        Using command As New MySqlCommand($"
SELECT 
    {columnName} 
FROM 
    {viewName}{If(filters.Length <> 0, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))}
", String.Empty)};", connection)
            ApplyFilters(filters, command, "")
            Return command.ExecuteScalar
        End Using
    End Function

    Public Sub PutColumnValue(viewName As String, value As (Column As String, Value As Object), ParamArray filters() As (Column As String, Value As Object)) Implements IDataStore.PutColumnValue
        Using command As New MySqlCommand($"
UPDATE 
    {viewName} 
SET 
    {value.Column} = @New{value.Column}{If(filters.Length <> 0, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))}
", String.Empty)};", connection)
            command.Parameters.AddWithValue($"@New{value.Column}", value.Value)
            ApplyFilters(filters, command, "")
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function Create(viewName As String, values As IEnumerable(Of (Column As String, Value As Object)), result As String) As Object Implements IDataStore.Create
        Using command As New MySqlCommand($"
INSERT INTO 
    {viewName}
        ({String.Join(",", values.Select(Function(x) x.Column))}) 
VALUES 
    ({String.Join(",", values.Select(Function(x) $"@{x.Column}"))}) 
RETURNING 
    {result};", connection)
            ApplyFilters(values, command, "")
            Return command.ExecuteScalar
        End Using
    End Function

    Public Sub Delete(
                     viewName As String,
                     filters As IEnumerable(Of (Column As String, Value As Object))) Implements IDataStore.Delete
        Using command As New MySqlCommand($"DELETE FROM {viewName}{If(filters.Any, $"
WHERE
    {String.Join(" AND ", filters.Select(Function(x) $"{x.Column} = @{x.Column}"))};", String.Empty)};", connection)
            ApplyFilters(filters, command, "")
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class
