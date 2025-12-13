Public Interface IDataStore
    Sub Open(connectionString As String)
    Sub Close()
    ReadOnly Property Profiles As IProfileStore
    ReadOnly Property Factions As IFactionStore
    ReadOnly Property Units As IUnitStore
    ReadOnly Property Buildings As IBuildingStore
    ReadOnly Property Housings As IHousingStore
    Function GetList(Of T)(
                          viewName As String,
                          columnNames As IEnumerable(Of String),
                          filters As IEnumerable(Of (Column As String, Value As Object)),
                          order As String,
                          callback As Func(Of IStoreResult, T)) As IEnumerable(Of T)
    Function GetColumnValue(
                           viewName As String,
                           columnName As String,
                           ParamArray filters() As (Column As String, Value As Object)) As Object
    Sub PutColumnValue(
                    viewName As String,
                    value As (Column As String, Value As Object),
                    ParamArray filters() As (Column As String, Value As Object))
    Function GetCount(
                     viewName As String,
                     filters As IEnumerable(Of (Column As String, Value As Object))) As Integer
    Function Create(
                   viewName As String,
                   values As IEnumerable(Of (Column As String, Value As Object)),
                   result As String) As Object
    Sub Delete(
            viewName As String,
            filters As IEnumerable(Of (Column As String, Value As Object)))
End Interface
