Imports KRAAL.Store

Friend Class UnitCounters
    Implements IUnitCounters

    Private ReadOnly store As IDataStore
    Private ReadOnly unitId As Integer

    Public Sub New(store As IDataStore, unitId As Integer)
        Me.store = store
        Me.unitId = unitId
    End Sub

    Public ReadOnly Property Unit As IUnit Implements IUnitCounters.Unit
        Get
            Return New Unit(store, unitId)
        End Get
    End Property

    Public ReadOnly Property All As IEnumerable(Of IUnitCounter) Implements IUnitCounters.All
        Get
            Return store.GetList(Of IUnitCounter)(
                TABLE_UNIT_COUNTERS,
                {COLUMN_UNIT_COUNTER_ID},
                {(COLUMN_UNIT_ID, unitId)},
                COLUMN_UNIT_COUNTER_ID,
                Function(x) New UnitCounter(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function Create(counterType As ICounterType, initialValue As Integer) As IUnitCounter Implements IUnitCounters.Create
        Return New UnitCounter(store, CInt(store.Create(
            TABLE_UNIT_COUNTERS,
            {
                (COLUMN_UNIT_ID, unitId),
                (COLUMN_COUNTER_TYPE_ID, counterType.CounterTypeId),
                (COLUMN_CURRENT_VALUE, initialValue)
            },
            COLUMN_UNIT_COUNTER_ID)))
    End Function
End Class
