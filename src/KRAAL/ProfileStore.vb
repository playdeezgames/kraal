Imports MySqlConnector

Friend Class ProfileStore
    Implements IProfileStore
    Const ALL_PROFILES = "SELECT profile_id, profile_name FROM profiles ORDER BY profile_name;"
    Const PROFILE_NAME_COUNT = "SELECT COUNT(1) FROM profiles WHERE profile_name = @profile_name;"
    Const PROFILE_ADD = "INSERT INTO profiles(profile_name) VALUES (@profile_name) RETURNING profile_id;"
    Const PROFILE_NAME_PARAMETER = "@profile_name"

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IProfile) Implements IProfileStore.All
        Get
            Dim result As New List(Of IProfile)
            Using command As New MySqlCommand(ALL_PROFILES, connection)
                Using reader = command.ExecuteReader()
                    While reader.Read()
                        result.Add(New Profile(reader.GetInt32(0), reader.GetString(1)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public Function DoesNameExist(profileName As String) As Boolean Implements IProfileStore.DoesNameExist
        Using command As New MySqlCommand(PROFILE_NAME_COUNT, connection)
            command.Parameters.AddWithValue(PROFILE_NAME_PARAMETER, profileName)
            Return CInt(command.ExecuteScalar()) > 0
        End Using
    End Function

    Public Function Create(profileName As String) As IProfile Implements IProfileStore.Create
        Using command As New MySqlCommand(PROFILE_ADD, connection)
            command.Parameters.AddWithValue(PROFILE_NAME_PARAMETER, profileName)
            Return New Profile(CInt(command.ExecuteScalar()), profileName)
        End Using
    End Function
End Class
