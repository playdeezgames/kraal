Imports MySqlConnector

Friend Class FactionStore
    Implements IFactionStore

    Private ReadOnly connection As MySqlConnection

    Private ReadOnly COUNT_FOR_PROFILE As String = $"
SELECT 
    COUNT({COLUMN_FACTION_ID}) 
FROM 
    {TABLE_FACTIONS} 
WHERE 
    {COLUMN_PROFILE_ID}={PARAMETER_PROFILE_ID};"

    Private ReadOnly FIND_FACTION_BY_PROFILE_ID_AND_FACTION_NAME As String = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_FACTIONS} 
WHERE 
    {COLUMN_PROFILE_ID} = {PARAMETER_PROFILE_ID} AND 
    {COLUMN_FACTION_NAME}={PARAMETER_FACTION_NAME}"

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

    Private ReadOnly LIST_FACTIONS_FOR_PROFILE As String = $"
SELECT
    {COLUMN_FACTION_ID},
    {COLUMN_FACTION_NAME}
FROM
    {TABLE_FACTIONS}
WHERE
    {COLUMN_PROFILE_ID} = {PARAMETER_PROFILE_ID}
ORDER BY
    {COLUMN_FACTION_NAME}"

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function CountForProfile(profile As IProfile) As Integer Implements IFactionStore.CountForProfile
        Using command As New MySqlCommand(COUNT_FOR_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            Return CInt(command.ExecuteScalar())
        End Using
    End Function

    Public Function DoesNameExist(profile As IProfile, factionName As String) As Boolean Implements IFactionStore.DoesNameExist
        Using command As New MySqlCommand(FIND_FACTION_BY_PROFILE_ID_AND_FACTION_NAME, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            command.Parameters.AddWithValue(PARAMETER_FACTION_NAME, factionName)
            Return CInt(command.ExecuteScalar()) > 0
        End Using
    End Function

    Public Function Create(profile As IProfile, factionName As String) As IFaction Implements IFactionStore.Create
        Using command As New MySqlCommand(INSERT_FACTION, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            command.Parameters.AddWithValue(PARAMETER_FACTION_NAME, factionName)
            Return New Faction(CInt(command.ExecuteScalar()), factionName)
        End Using
    End Function

    Public Function AllForProfile(profile As IProfile) As IEnumerable(Of IFaction) Implements IFactionStore.AllForProfile
        Dim result As New List(Of IFaction)
        Using command As New MySqlCommand(LIST_FACTIONS_FOR_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    result.Add(New Faction(reader.GetInt32(0), reader.GetString(1)))
                End While
            End Using
        End Using
        Return result
    End Function
End Class
