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

    Public ReadOnly Property UnitType As IUnitType Implements IUnitTypeCounter.UnitType
        Get
            Return New UnitType(
                store,
                CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_UNIT_TYPE_ID,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId))))
        End Get
    End Property

    Public Property InitialValue As Integer Implements IUnitTypeCounter.InitialValue
        Get
            Return CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_INITIAL_VALUE,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)))
        End Get
        Set(value As Integer)
            store.PutColumnValue(
                TABLE_UNIT_TYPE_COUNTERS,
                (COLUMN_INITIAL_VALUE, value),
                (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId))
        End Set
    End Property

    Public Property MinimumValue As Integer Implements IUnitTypeCounter.MinimumValue
        Get
            Return CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_MINIMUM_VALUE,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)))
        End Get
        Set(value As Integer)
            store.PutColumnValue(
                TABLE_UNIT_TYPE_COUNTERS,
                (COLUMN_MINIMUM_VALUE, value),
                (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId))
        End Set
    End Property

    Public Property MaximumValue As Integer Implements IUnitTypeCounter.MaximumValue
        Get
            Return CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_MAXIMUM_VALUE,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)))
        End Get
        Set(value As Integer)
            store.PutColumnValue(
                TABLE_UNIT_TYPE_COUNTERS,
                (COLUMN_MAXIMUM_VALUE, value),
                (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId))
        End Set
    End Property

    Public Sub Remove() Implements IUnitTypeCounter.Remove
        store.Delete(
            TABLE_UNIT_TYPE_COUNTERS,
            {
                (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)
            })
    End Sub
End Class
