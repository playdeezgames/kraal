Imports KRAAL.Store

Friend Class UnitCounter
    Implements IUnitCounter

    Private ReadOnly store As IDataStore
    Private ReadOnly unitCounterId As Integer

    Public Sub New(store As IDataStore, unitCounterId As Integer)
        Me.store = store
        Me.unitCounterId = unitCounterId
    End Sub

    Public ReadOnly Property CounterType As ICounterType Implements IUnitCounter.CounterType
        Get
            Return New CounterType(store, CInt(store.GetColumnValue(TABLE_UNIT_COUNTERS, COLUMN_COUNTER_TYPE_ID, (COLUMN_UNIT_COUNTER_ID, unitCounterId))))
        End Get
    End Property

    Public ReadOnly Property Unit As IUnit Implements IUnitCounter.Unit
        Get
            Return New Unit(store, CInt(store.GetColumnValue(TABLE_UNIT_COUNTERS, COLUMN_UNIT_ID, (COLUMN_UNIT_COUNTER_ID, unitCounterId))))
        End Get
    End Property

    Public ReadOnly Property CurrentValue As Integer Implements IUnitCounter.CurrentValue
        Get
            Return CInt(store.GetColumnValue(TABLE_UNIT_COUNTERS, COLUMN_CURRENT_VALUE, (COLUMN_UNIT_COUNTER_ID, unitCounterId)))
        End Get
    End Property
End Class
