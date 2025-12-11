Imports MySqlConnector

Friend Class FactionStore
    Implements IFactionStore

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Sub Remove(faction As IFactionDTO) Implements IFactionStore.Remove
        connection.Delete(TABLE_FACTIONS, {(COLUMN_FACTION_ID, faction.FactionId)})
    End Sub

    Public Function CountForProfile(profile As IProfileDTO) As Integer Implements IFactionStore.CountForProfile
        Return connection.GetCount(TABLE_FACTIONS, {(COLUMN_PROFILE_ID, profile.ProfileId)})
    End Function

    Public Function DoesNameExist(profile As IProfileDTO, factionName As String) As Boolean Implements IFactionStore.DoesNameExist
        Return connection.GetCount(
            TABLE_FACTIONS,
            {
                (COLUMN_PROFILE_ID, profile.ProfileId),
                (COLUMN_FACTION_NAME, factionName)
            }) > 0
    End Function

    Public Function Create(profile As IProfileDTO, factionName As String) As IFactionDTO Implements IFactionStore.Create
        Return New FactionDTO(CInt(
                           connection.Create(
                                TABLE_FACTIONS,
                                {
                                    (COLUMN_FACTION_NAME, factionName),
                                    (COLUMN_PROFILE_ID, profile.ProfileId)
                                },
                                COLUMN_FACTION_ID)), factionName)
    End Function

    Public Function AllForProfile(profile As IProfileDTO) As IEnumerable(Of IFactionDTO) Implements IFactionStore.AllForProfile
        Return connection.GetList(Of IFactionDTO)(
            TABLE_FACTIONS,
            {
                COLUMN_FACTION_ID,
                COLUMN_FACTION_NAME
            },
            {
                (COLUMN_PROFILE_ID, profile.ProfileId)
            },
            COLUMN_FACTION_NAME,
            Function(reader) New FactionDTO(reader.GetInt32(0), reader.GetString(1)))
    End Function
End Class
