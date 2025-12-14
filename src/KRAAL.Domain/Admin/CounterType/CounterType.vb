Imports KRAAL.Store

Friend Class CounterType
    Implements ICounterType

    Friend Sub New(store As IDataStore, counterTypeId As Integer)
        Me.store = store
        Me.CounterTypeId = counterTypeId
    End Sub

    Public Sub Remove() Implements ICounterType.Remove
        store.Delete(TABLE_COUNTER_TYPES, {(COLUMN_COUNTER_TYPE_ID, CounterTypeId)})
    End Sub

    Private ReadOnly store As IDataStore
    Public ReadOnly Property CounterTypeId As Integer Implements ICounterType.CounterTypeId

    Public Property CounterTypeName As String Implements ICounterType.CounterTypeName
        Get
            Return CStr(store.GetColumnValue(TABLE_COUNTER_TYPES, COLUMN_COUNTER_TYPE_NAME, (COLUMN_COUNTER_TYPE_ID, CounterTypeId)))
        End Get
        Set(value As String)
            store.PutColumnValue(TABLE_COUNTER_TYPES, (COLUMN_COUNTER_TYPE_NAME, value), (COLUMN_COUNTER_TYPE_ID, CounterTypeId))
        End Set
    End Property

    Public ReadOnly Property CounterTypes As ICounterTypes Implements ICounterType.CounterTypes
        Get
            Return New CounterTypes(store)
        End Get
    End Property
End Class
