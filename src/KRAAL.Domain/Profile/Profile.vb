Imports KRAAL.Store

Friend Class Profile
    Implements IProfile

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore, profileId As Integer)
        Me.store = store
        Me.ProfileId = profileId
    End Sub

    Public ReadOnly Property ProfileId As Integer Implements IProfile.ProfileId

    Public Property ProfileName As String Implements IProfile.ProfileName
        Get
            Return CStr(store.GetColumnValue(
                TABLE_PROFILES,
                COLUMN_PROFILE_NAME,
                (COLUMN_PROFILE_ID, ProfileId)))
        End Get
        Set(value As String)
            store.PutColumnValue(
                TABLE_PROFILES,
                (COLUMN_PROFILE_NAME, value),
                (COLUMN_PROFILE_ID, ProfileId))
        End Set
    End Property

    Public ReadOnly Property FactionCount As Integer Implements IProfile.FactionCount
        Get
            Return store.GetCount(TABLE_FACTIONS, {(COLUMN_PROFILE_ID, ProfileId)})
        End Get
    End Property

    Public ReadOnly Property AllFactions As IEnumerable(Of IFaction) Implements IProfile.AllFactions
        Get
            Return store.GetList(Of IFaction)(
                TABLE_FACTIONS,
                {
                    COLUMN_FACTION_ID
                },
                {
                    (COLUMN_PROFILE_ID, ProfileId)
                },
                COLUMN_FACTION_ID,
                Function(x) New Faction(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property Profiles As IProfiles Implements IProfile.Profiles
        Get
            Return New Profiles(store)
        End Get
    End Property

    Public Sub Remove() Implements IProfile.Remove
        store.Delete(TABLE_PROFILES, {(COLUMN_PROFILE_ID, ProfileId)})
    End Sub

    Public Function DoesFactionNameExist(factionName As String) As Boolean Implements IProfile.DoesFactionNameExist
        Return store.GetCount(
            TABLE_FACTIONS,
            {
                (COLUMN_PROFILE_ID, ProfileId),
                (COLUMN_FACTION_NAME, factionName)
            }) > 0
    End Function

    Public Function CreateFaction(factionName As String) As IFaction Implements IProfile.CreateFaction
        Return New Faction(
            store,
            CInt(store.Create(
                TABLE_FACTIONS,
                {
                    (COLUMN_PROFILE_ID, ProfileId),
                    (COLUMN_FACTION_NAME, factionName)
                },
                COLUMN_FACTION_ID)))
    End Function
End Class
