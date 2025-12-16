Imports KRAAL.Store

Friend Class BuildingType
    Implements IBuildingType

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore, buildingTypeId As Integer)
        Me.store = store
        Me.buildingTypeId = buildingTypeId
    End Sub

    Public Property BuildingTypeName As String Implements IBuildingType.BuildingTypeName
        Get
            Return CStr(store.GetColumnValue(TABLE_BUILDING_TYPES, COLUMN_BUILDING_TYPE_NAME, (COLUMN_BUILDING_TYPE_ID, buildingTypeId)))
        End Get
        Set(value As String)
            store.PutColumnValue(TABLE_BUILDING_TYPES, (COLUMN_BUILDING_TYPE_NAME, value), (COLUMN_BUILDING_TYPE_ID, buildingTypeId))
        End Set
    End Property

    Public ReadOnly Property BuildingTypeId As Integer Implements IBuildingType.BuildingTypeId

    Public ReadOnly Property BuildingTypes As IBuildingTypes Implements IBuildingType.BuildingTypes
        Get
            Return New BuildingTypes(store)
        End Get
    End Property

    Public Sub Remove() Implements IBuildingType.Remove
        store.Delete(TABLE_BUILDING_TYPES, {(COLUMN_BUILDING_TYPE_ID, BuildingTypeId)})
    End Sub
End Class
