Imports KRAAL.Store

Friend Class Faction
    Implements IFaction

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore, factionId As Integer)
        Me.store = store
        Me.FactionId = factionId
    End Sub

    Public ReadOnly Property FactionId As Integer Implements IFaction.FactionId

    Public Property FactionName As String Implements IFaction.FactionName
        Get
            Return CStr(store.GetColumnValue(
                TABLE_FACTIONS,
                COLUMN_FACTION_NAME,
                (COLUMN_FACTION_ID, FactionId)))
        End Get
        Set(value As String)
            store.PutColumnValue(
                TABLE_FACTIONS,
                (COLUMN_FACTION_NAME, value),
                (COLUMN_FACTION_ID, FactionId))
        End Set
    End Property

    Public ReadOnly Property AllUnits As IEnumerable(Of IUnit) Implements IFaction.AllUnits
        Get
            Return store.GetList(Of IUnit)(
                TABLE_UNITS,
                {
                    COLUMN_UNIT_ID
                },
                {
                    (COLUMN_FACTION_ID, FactionId)
                },
                COLUMN_UNIT_NAME,
                Function(x) New Unit(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property BuildingCount As Integer Implements IFaction.BuildingCount
        Get
            Return store.GetCount(TABLE_BUILDINGS, {(COLUMN_FACTION_ID, FactionId)})
        End Get
    End Property

    Public ReadOnly Property UnitCount As Integer Implements IFaction.UnitCount
        Get
            Return store.GetCount(TABLE_UNITS, {(COLUMN_FACTION_ID, FactionId)})
        End Get
    End Property

    Public ReadOnly Property AllBuildings As IEnumerable(Of IBuilding) Implements IFaction.AllBuildings
        Get
            Return store.GetList(Of IBuilding)(
                TABLE_BUILDINGS,
                {
                    COLUMN_BUILDING_ID
                },
                {
                    (COLUMN_FACTION_ID, FactionId)
                },
                COLUMN_BUILDING_NAME,
                Function(x) New Building(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property HasAvailableHousing As Boolean Implements IFaction.HasAvailableHousing
        Get
            Return store.GetCount(VIEW_FACTION_AVAILABLE_HOUSINGS, {(COLUMN_FACTION_ID, FactionId)}) > 0
        End Get
    End Property

    Public ReadOnly Property AvailableHousing As IEnumerable(Of IHousing) Implements IFaction.AvailableHousing
        Get
            Return store.GetList(Of IHousing)(
                VIEW_FACTION_AVAILABLE_HOUSINGS,
                {COLUMN_HOUSING_ID},
                {(COLUMN_FACTION_ID, FactionId)},
                COLUMN_HOUSING_ID,
                Function(x) New Housing(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property HasUnhousedUnits As Boolean Implements IFaction.HasUnhousedUnits
        Get
            Return store.GetCount(VIEW_FACTION_UNHOUSED_UNITS, {(COLUMN_FACTION_ID, FactionId)}) > 0
        End Get
    End Property

    Public ReadOnly Property UnhousedUnits As IEnumerable(Of IUnit) Implements IFaction.UnhousedUnits
        Get
            Return store.GetList(Of IUnit)(
                VIEW_FACTION_UNHOUSED_UNITS,
                {
                    COLUMN_UNIT_ID
                },
                {
                    (COLUMN_FACTION_ID, FactionId)
                },
                COLUMN_UNIT_ID,
                Function(x) New Unit(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property Profile As IProfile Implements IFaction.Profile
        Get
            Return New Profile(
                store,
                CInt(store.GetColumnValue(TABLE_FACTIONS, COLUMN_PROFILE_ID, (COLUMN_FACTION_ID, FactionId))))
        End Get
    End Property

    Public Sub Remove() Implements IFaction.Remove
        store.Delete(TABLE_FACTIONS, {(COLUMN_FACTION_ID, FactionId)})
    End Sub

    Public Function CreateUnit(unitName As String, housing As IHousing) As IUnit Implements IFaction.CreateUnit
        Return New Unit(
            store,
            CInt(store.Create(
                TABLE_UNITS,
                {
                    (COLUMN_UNIT_NAME, unitName),
                    (COLUMN_HOUSING_ID, housing?.HousingId),
                    (COLUMN_FACTION_ID, FactionId)
                },
                COLUMN_UNIT_ID)))
    End Function

    Public Function CreateBuilding(buildingName As String) As IBuilding Implements IFaction.CreateBuilding
        Return New Building(
            store,
            CInt(store.Create(
                TABLE_BUILDINGS,
                {
                    (COLUMN_BUILDING_NAME, buildingName),
                    (COLUMN_FACTION_ID, FactionId)
                },
                COLUMN_BUILDING_ID)))
    End Function
End Class
