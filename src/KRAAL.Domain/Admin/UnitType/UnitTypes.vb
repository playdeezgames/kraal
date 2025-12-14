Imports KRAAL.Store

Friend Class UnitTypes
    Implements IUnitTypes

    Private store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IUnitType) Implements IUnitTypes.All
        Get
            Return store.GetList(Of IUnitType)(
                TABLE_UNIT_TYPES,
                {
                    COLUMN_UNIT_TYPE_ID
                },
                {},
                COLUMN_UNIT_TYPE_NAME,
                Function(x) New UnitType(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function DoesNameExist(name As String) As Boolean Implements IUnitTypes.DoesNameExist
        Return store.GetCount(TABLE_UNIT_TYPES, {(COLUMN_UNIT_TYPE_NAME, name)}) > 0
    End Function

    Public Function Create(name As String) As IUnitType Implements IUnitTypes.Create
        Return New UnitType(store, CInt(store.Create(TABLE_UNIT_TYPES, {(COLUMN_UNIT_TYPE_NAME, name)}, COLUMN_UNIT_TYPE_ID)))
    End Function
End Class
