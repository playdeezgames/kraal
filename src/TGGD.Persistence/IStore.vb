Public Interface IStore
    Function GetCount(
                     viewName As String,
                     ParamArray filters() As (Column As String, Value As Object)) As Integer
    Function Create(
                   viewName As String,
                   columnValues As IEnumerable(Of (Column As String, Value As Object)),
                   resultColumn As String) As Object
    Function GetColumnValue(
                           viewName As String,
                           columnName As String,
                           ParamArray filters() As (Column As String, Value As Object)) As Object
    Sub SetColumnValue(
                      viewName As String,
                      columnValue As (Column As String, Value As Object),
                      ParamArray filters() As (Column As String, Compare As Compare, Value As Object))
    Function GetRecords(Of TResult)(
                                   viewName As String,
                                   columnNames As IEnumerable(Of String),
                                   filters As IEnumerable(Of (Column As String, Compare As Compare, Value As Object)),
                                   converter As Func(Of IRecord, TResult)) As IEnumerable(Of TResult)
    Sub Delete(
            viewName As String,
            ParamArray filters() As (Column As String, Compare As Compare, Value As Object))
    Sub Export(filename As String)
    Sub Import(filename As String)
End Interface
