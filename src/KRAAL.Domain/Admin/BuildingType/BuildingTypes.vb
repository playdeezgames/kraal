Imports KRAAL.Store

Friend Class BuildingTypes
    Implements IBuildingTypes

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub
End Class
