Imports MySqlConnector

Friend Class ProfileStore
    Implements IProfileStore
    Private ReadOnly INSERT_PROFILE As String = $"
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
    Private ReadOnly DELETE_PROFILE As String = $"
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
            Return connection.GetList(Of IProfile)(
                TABLE_PROFILES,
                {
                    COLUMN_PROFILE_ID,
                    COLUMN_PROFILE_NAME
                },
                Array.Empty(Of (String, Object)),
                COLUMN_PROFILE_NAME,
                Function(reader) New Profile(reader.GetInt32(0), reader.GetString(1)))
        End Get
    End Property

    Public Sub Remove(profile As IProfile) Implements IProfileStore.Remove
        Using command As New MySqlCommand(DELETE_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_ID, profile.ProfileId)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function DoesNameExist(profileName As String) As Boolean Implements IProfileStore.DoesNameExist
        Return connection.GetCount(
            TABLE_PROFILES,
            {
                (COLUMN_PROFILE_NAME, profileName)
            }) > 0
    End Function

    Public Function Create(profileName As String) As IProfile Implements IProfileStore.Create
        Using command As New MySqlCommand(INSERT_PROFILE, connection)
            command.Parameters.AddWithValue(PARAMETER_PROFILE_NAME, profileName)
            Return New Profile(CInt(command.ExecuteScalar()), profileName)
        End Using
    End Function
End Class
