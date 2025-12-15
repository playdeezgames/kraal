Imports KRAAL.Store

Friend Class UnitTypeCounter
    Implements IUnitTypeCounter

    Private ReadOnly store As IDataStore
    Private ReadOnly unitTypeCounterId As Integer

    Public Sub New(store As IDataStore, unitTypeCounterId As Integer)
        Me.store = store
        Me.unitTypeCounterId = unitTypeCounterId
    End Sub

    Public ReadOnly Property CounterType As ICounterType Implements IUnitTypeCounter.CounterType
        Get
            Return New CounterType(
                store,
                CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_COUNTER_TYPE_ID,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId))))
        End Get
    End Property
End Class
