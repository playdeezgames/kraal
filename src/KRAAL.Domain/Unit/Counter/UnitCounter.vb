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

    Public Property CurrentValue As Integer Implements IUnitCounter.CurrentValue
        Get
            Return CInt(store.GetColumnValue(TABLE_UNIT_COUNTERS, COLUMN_CURRENT_VALUE, (COLUMN_UNIT_COUNTER_ID, unitCounterId)))
        End Get
        Set(value As Integer)
            store.PutColumnValue(TABLE_UNIT_COUNTERS, (COLUMN_CURRENT_VALUE, value), (COLUMN_UNIT_COUNTER_ID, unitCounterId))
        End Set
    End Property

    Public ReadOnly Property UnitTypeCounter As IUnitTypeCounter Implements IUnitCounter.UnitTypeCounter
        Get
            Return New UnitTypeCounter(
                store,
                CInt(store.GetColumnValue(
                    VIEW_UNIT_COUNTER_DETAILS,
                    COLUMN_UNIT_TYPE_COUNTER_ID,
                    (COLUMN_UNIT_COUNTER_ID, unitCounterId))))
        End Get
    End Property
End Class
