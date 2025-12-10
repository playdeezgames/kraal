Imports MySqlConnector

Friend Class FactionStore
    Implements IFactionStore

    Private ReadOnly connection As MySqlConnection

    Private ReadOnly INSERT_FACTION As String = $"
INSERT INTO 
    {TABLE_FACTIONS}
        (
            {COLUMN_PROFILE_ID},
            {COLUMN_FACTION_NAME}
        )
VALUES
    (
        {PARAMETER_PROFILE_ID},
        {PARAMETER_FACTION_NAME}
    )
RETURNING
    {COLUMN_FACTION_ID};"

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
        Using command As New MySqlCommand(INSERT_FACTION, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            command.Parameters.AddWithValue(PARAMETER_FACTION_NAME, factionName)
            Return New Faction(CInt(command.ExecuteScalar()), factionName)
        End Using
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
