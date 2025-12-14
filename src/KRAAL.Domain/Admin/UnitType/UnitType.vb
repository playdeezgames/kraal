Imports KRAAL.Store

Friend Class UnitType
    Implements IUnitType

    Friend Sub New(store As IDataStore, unitTypeId As Integer)
        Me.store = store
        Me.UnitTypeId = unitTypeId
    End Sub

    Public Sub Remove() Implements IUnitType.Remove
        store.Delete(TABLE_UNIT_TYPES, {(COLUMN_UNIT_TYPE_ID, UnitTypeId)})
    End Sub

    Private ReadOnly store As IDataStore
    Public ReadOnly Property UnitTypeId As Integer Implements IUnitType.UnitTypeId

    Public Property UnitTypeName As String Implements IUnitType.UnitTypeName
        Get
            Return CStr(store.GetColumnValue(
                TABLE_UNIT_TYPES,
                COLUMN_UNIT_TYPE_NAME,
                (COLUMN_UNIT_TYPE_ID, UnitTypeId)))
        End Get
        Set(value As String)
            store.PutColumnValue(TABLE_UNIT_TYPES, (COLUMN_UNIT_TYPE_NAME, value), (COLUMN_UNIT_TYPE_ID, UnitTypeId))
        End Set
    End Property

    Public ReadOnly Property UnitTypes As IUnitTypes Implements IUnitType.UnitTypes
        Get
            Return New UnitTypes(store)
        End Get
    End Property
End Class
