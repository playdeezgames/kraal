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

    Public ReadOnly Property InitialValue As Integer Implements IUnitTypeCounter.InitialValue
        Get
            Return CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_INITIAL_VALUE,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)))
        End Get
    End Property

    Public ReadOnly Property MinimumValue As Integer Implements IUnitTypeCounter.MinimumValue
        Get
            Return CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_MINIMUM_VALUE,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)))
        End Get
    End Property

    Public ReadOnly Property MaximumValue As Integer Implements IUnitTypeCounter.MaximumValue
        Get
            Return CInt(store.GetColumnValue(
                    TABLE_UNIT_TYPE_COUNTERS,
                    COLUMN_MAXIMUM_VALUE,
                    (COLUMN_UNIT_TYPE_COUNTER_ID, unitTypeCounterId)))
        End Get
    End Property
End Class
