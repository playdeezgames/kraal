Imports KRAAL.Store

Friend Class UnitTypes
    Implements IUnitTypes

    Private store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub
End Class
