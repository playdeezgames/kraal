Imports MySqlConnector

Friend Class FactionStore
    Implements IFactionStore

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function CountForProfile(profile As IProfile) As Integer Implements IFactionStore.CountForProfile
        Return connection.GetCount(TABLE_FACTIONS, {(COLUMN_PROFILE_ID, profile.ProfileId)})
    End Function

    Public Function DoesNameExist(profile As IProfile, factionName As String) As Boolean Implements IFactionStore.DoesNameExist
        Return connection.GetCount(
            TABLE_FACTIONS,
            {
                (COLUMN_PROFILE_ID, profile.ProfileId),
                (COLUMN_FACTION_NAME, factionName)
            }) > 0
    End Function

    Public Function Create(profile As IProfile, factionName As String) As IFaction Implements IFactionStore.Create
        Return New Faction(CInt(
                           connection.Create(
                                TABLE_FACTIONS,
                                {
                                    (COLUMN_FACTION_NAME, factionName),
                                    (COLUMN_PROFILE_ID, profile.ProfileId)
                                },
                                COLUMN_FACTION_ID)), factionName)
    End Function

    Public Function AllForProfile(profile As IProfile) As IEnumerable(Of IFaction) Implements IFactionStore.AllForProfile
        Return connection.GetList(Of IFaction)(
            TABLE_FACTIONS,
            {
                COLUMN_FACTION_ID,
                COLUMN_FACTION_NAME
            },
            {
                (COLUMN_PROFILE_ID, profile.ProfileId)
            },
            COLUMN_FACTION_NAME,
            Function(reader) New Faction(reader.GetInt32(0), reader.GetString(1)))
    End Function
End Class
