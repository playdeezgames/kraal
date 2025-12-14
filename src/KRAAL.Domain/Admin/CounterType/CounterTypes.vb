Imports KRAAL.Store

Friend Class CounterTypes
    Implements ICounterTypes

    Private store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub

    Public ReadOnly Property All As IEnumerable(Of ICounterType) Implements ICounterTypes.All
        Get
            Return store.GetList(Of ICounterType)(
                TABLE_COUNTER_TYPES,
                {
                    COLUMN_COUNTER_TYPE_ID
                },
                {},
                COLUMN_COUNTER_TYPE_NAME,
                Function(x) New CounterType(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function DoesNameExist(name As String) As Boolean Implements ICounterTypes.DoesNameExist
        Return store.GetCount(TABLE_COUNTER_TYPES, {(COLUMN_COUNTER_TYPE_NAME, name)}) > 0
    End Function

    Public Function Create(name As String) As ICounterType Implements ICounterTypes.Create
        Return New CounterType(store, CInt(store.Create(TABLE_COUNTER_TYPES, {(COLUMN_COUNTER_TYPE_NAME, name)}, COLUMN_COUNTER_TYPE_ID)))
    End Function
End Class
