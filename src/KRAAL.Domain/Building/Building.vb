Imports KRAAL.Store

Friend Class Building
    Implements IBuilding
    Private ReadOnly store As IDataStore
    Sub New(store As IDataStore, buildingId As Integer)
        Me.BuildingId = buildingId
        Me.store = store
    End Sub

    Public ReadOnly Property BuildingId As Integer Implements IBuilding.BuildingId

    Public Property BuildingName As String Implements IBuilding.BuildingName
        Get
            Return CStr(store.GetColumnValue(TABLE_BUILDINGS, COLUMN_BUILDING_NAME, (COLUMN_BUILDING_ID, BuildingId)))
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public ReadOnly Property HousingCount As Integer Implements IBuilding.HousingCount
        Get
            Return store.GetCount(TABLE_HOUSINGS, {(COLUMN_BUILDING_ID, BuildingId)})
        End Get
    End Property

    Public ReadOnly Property Housings As IEnumerable(Of IHousing) Implements IBuilding.Housings
        Get
            Return store.GetList(Of Integer)(
                    TABLE_HOUSINGS,
                    {
                        COLUMN_HOUSING_ID
                    },
                    {
                        (COLUMN_BUILDING_ID, BuildingId)
                    },
                    COLUMN_HOUSING_ID,
                    Function(x) x.GetInt32(0)).
                Select(Function(x) New Housing(store, x))
        End Get
    End Property

    Public Function CreateHousing() As IHousing Implements IBuilding.CreateHousing
        Return New Housing(store, CInt(store.Create(TABLE_HOUSINGS, {(COLUMN_BUILDING_ID, BuildingId)}, COLUMN_HOUSING_ID)))
    End Function

    Public Function UniqueName() As String Implements IBuilding.UniqueName
        Return $"{BuildingName}(#{BuildingId})"
    End Function
End Class
