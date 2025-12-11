Imports MySqlConnector

Friend Class ProfileStore
    Implements IProfileStore
    Private ReadOnly connection As MySqlConnection

    Friend Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IProfileDTO) Implements IProfileStore.All
        Get
            Return connection.GetList(Of IProfileDTO)(
                TABLE_PROFILES,
                {
                    COLUMN_PROFILE_ID,
                    COLUMN_PROFILE_NAME
                },
                Array.Empty(Of (String, Object)),
                COLUMN_PROFILE_NAME,
                Function(reader, result) New ProfileDTO(result.GetInt32(0), result.GetString(1)))
        End Get
    End Property

    Public Sub Remove(profile As IProfileDTO) Implements IProfileStore.Remove
        connection.Delete(TABLE_PROFILES, {(COLUMN_PROFILE_ID, profile.ProfileId)})
    End Sub

    Public Function DoesNameExist(profileName As String) As Boolean Implements IProfileStore.DoesNameExist
        Return connection.GetCount(
            TABLE_PROFILES,
            {
                (COLUMN_PROFILE_NAME, profileName)
            }) > 0
    End Function

    Public Function Create(profileName As String) As IProfileDTO Implements IProfileStore.Create
        Return New ProfileDTO(
            CInt(connection.Create(
                TABLE_PROFILES,
                {
                    (COLUMN_PROFILE_NAME, profileName)
                },
                COLUMN_PROFILE_ID)), profileName)
    End Function
End Class
