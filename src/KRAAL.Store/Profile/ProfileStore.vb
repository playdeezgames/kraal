Imports MySqlConnector

Friend Class ProfileStore
    Implements IProfileStore
    Friend ReadOnly LIST_PROFILES As String = $"
SELECT 
    {COLUMN_PROFILE_ID}, 
    {COLUMN_PROFILE_NAME} 
FROM 
    {TABLE_PROFILES} 
ORDER BY 
    {COLUMN_PROFILE_NAME};"
    Friend ReadOnly FIND_PROFILE_BY_NAME As String = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_PROFILES} 
WHERE 
    {COLUMN_PROFILE_NAME} = {PARAMETER_PROFILE_NAME};"
    Friend ReadOnly INSERT_PROFILE As String = $"
INSERT INTO 
    {TABLE_PROFILES}
        (
            {COLUMN_PROFILE_NAME}
        ) 
VALUES 
    (
        {PARAMETER_PROFILE_NAME}
    ) 
RETURNING 
    {COLUMN_PROFILE_ID};"
    Friend ReadOnly DELETE_PROFILE As String = $"
DELETE FROM 
    {TABLE_PROFILES} 
WHERE 
    {COLUMN_PROFILE_ID} = {PARAMETER_PROFILE_ID};"

    Private ReadOnly connection As MySqlConnection

    Friend Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IProfile) Implements IProfileStore.All
        Get
            Dim result As New List(Of IProfile)
            Using command As New MySqlCommand(LIST_PROFILES, connection)
                Using reader = command.ExecuteReader()
                    While reader.Read()
                        result.Add(New Profile(reader.GetInt32(0), reader.GetString(1)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public Sub Remove(profile As IProfile) Implements IProfileStore.Remove
        Using command As New MySqlCommand(DELETE_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function DoesNameExist(profileName As String) As Boolean Implements IProfileStore.DoesNameExist
        Using command As New MySqlCommand(FIND_PROFILE_BY_NAME, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_NAME, profileName)
            Return CInt(command.ExecuteScalar()) > 0
        End Using
    End Function

    Public Function Create(profileName As String) As IProfile Implements IProfileStore.Create
        Using command As New MySqlCommand(INSERT_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_NAME, profileName)
            Return New Profile(CInt(command.ExecuteScalar()), profileName)
        End Using
    End Function
End Class
