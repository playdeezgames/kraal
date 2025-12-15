Imports KRAAL.Store

Friend Class UnitCounter
    Implements IUnitCounter

    Private ReadOnly store As IDataStore
    Private ReadOnly unitCounterId As Integer

    Public Sub New(store As IDataStore, unitCounterId As Integer)
        Me.store = store
        Me.unitCounterId = unitCounterId
    End Sub
End Class
