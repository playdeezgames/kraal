Imports KRAAL.Store

Friend Class BuildingTypes
    Implements IBuildingTypes

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IBuildingType) Implements IBuildingTypes.All
        Get
            Return store.GetList(Of IBuildingType)(
                TABLE_BUILDING_TYPES,
                {
                    COLUMN_BUILDING_TYPE_ID
                },
                {},
                COLUMN_BUILDING_TYPE_NAME,
                Function(x) New BuildingType(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function DoesNameExist(buildingTypeName As String) As Boolean Implements IBuildingTypes.DoesNameExist
        Return store.GetCount(TABLE_BUILDING_TYPES, {(COLUMN_BUILDING_TYPE_NAME, buildingTypeName)}) > 0
    End Function

    Public Function Create(buildingTypeName As String) As IBuildingType Implements IBuildingTypes.Create
        Return New BuildingType(store, CInt(store.Create(TABLE_BUILDING_TYPES, {(COLUMN_BUILDING_TYPE_NAME, buildingTypeName)}, COLUMN_BUILDING_TYPE_ID)))
    End Function

    Public Function FindByName(buildingTypeName As String) As IBuildingType Implements IBuildingTypes.FindByName
        Return store.GetList(Of IBuildingType)(
            TABLE_BUILDING_TYPES,
            {COLUMN_BUILDING_TYPE_ID},
            {(COLUMN_BUILDING_TYPE_NAME, buildingTypeName)},
            COLUMN_BUILDING_TYPE_ID,
            Function(x) New BuildingType(store, x.GetInt32(0))
            ).SingleOrDefault()
    End Function
End Class
