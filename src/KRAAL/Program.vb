Imports KRAAL.Domain
Imports KRAAL.Store

Module Program
    Const CONNECTION_STRING = "Server=localhost;Port=3306;Database=kraal;Uid=root;Pwd=;"
    Sub Main(args As String())
        Dim store As IDataStore = New DataStore()
        store.Open(CONNECTION_STRING)
        ProfileList.Run(New Profiles(store))
        store.Close()
    End Sub
End Module
