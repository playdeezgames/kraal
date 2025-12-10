Imports MySqlConnector

Friend Class FactionStore
    Implements IFactionStore

    Private ReadOnly connection As MySqlConnection
    Friend ReadOnly COUNT_FOR_PROFILE As String = $"
SELECT 
    COUNT({COLUMN_FACTION_ID}) 
FROM 
    {TABLE_FACTIONS} 
WHERE 
    {COLUMN_PROFILE_ID}={PARAMETER_PROFILE_ID};"

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function CountForProfile(profile As IProfile) As Integer Implements IFactionStore.CountForProfile
        Using command As New MySqlCommand(COUNT_FOR_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            Return CInt(command.ExecuteScalar())
        End Using
    End Function
End Class
