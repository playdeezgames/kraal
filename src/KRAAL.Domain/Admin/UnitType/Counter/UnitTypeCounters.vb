Imports KRAAL.Store

Friend Class UnitTypeCounters
    Implements IUnitTypeCounters

    Private ReadOnly store As IDataStore
    Private ReadOnly unitTypeId As Integer

    Public Sub New(store As IDataStore, unitTypeId As Integer)
        Me.store = store
        Me.unitTypeId = unitTypeId
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IUnitTypeCounter) Implements IUnitTypeCounters.All
        Get
            Return store.GetList(Of IUnitTypeCounter)(
                TABLE_UNIT_TYPE_COUNTERS,
                {COLUMN_UNIT_TYPE_COUNTER_ID},
                {(COLUMN_UNIT_TYPE_ID, unitTypeId)},
                COLUMN_UNIT_TYPE_COUNTER_ID,
                Function(x) New UnitTypeCounter(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property UnitType As IUnitType Implements IUnitTypeCounters.UnitType
        Get
            Return New UnitType(store, unitTypeId)
        End Get
    End Property

    Public ReadOnly Property AvailableCounterTypes As IEnumerable(Of ICounterType) Implements IUnitTypeCounters.AvailableCounterTypes
        Get
            Return store.GetList(Of ICounterType)(
                VIEW_UNIT_TYPE_AVAILABLE_COUNTER_TYPES,
                {COLUMN_COUNTER_TYPE_ID},
                {(COLUMN_UNIT_TYPE_ID, unitTypeId)},
                COLUMN_COUNTER_TYPE_ID,
                Function(x) New CounterType(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function Create(
                          counterType As ICounterType,
                          initial As Integer,
                          minimum As Integer,
                          maximum As Integer) As IUnitTypeCounter Implements IUnitTypeCounters.Create
        Return New UnitTypeCounter(store, CInt(store.Create(
            TABLE_UNIT_TYPE_COUNTERS,
            {
                (COLUMN_UNIT_TYPE_ID, unitTypeId),
                (COLUMN_COUNTER_TYPE_ID, counterType.CounterTypeId),
                (COLUMN_INITIAL_VALUE, initial),
                (COLUMN_MINIMUM_VALUE, minimum),
                (COLUMN_MAXIMUM_VALUE, maximum)
            },
            COLUMN_UNIT_TYPE_COUNTER_ID)))
    End Function
End Class
