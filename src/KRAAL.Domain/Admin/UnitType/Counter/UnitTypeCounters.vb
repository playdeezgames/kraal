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
End Class
