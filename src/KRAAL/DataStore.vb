Imports MySqlConnector

Public Class DataStore
    Implements IDataStore
    Private connection As MySqlConnection
    Const ALL_PROFILES = "SELECT profile_id, profile_name FROM profiles ORDER BY profile_name;"
    Const PROFILE_NAME_COUNT = "SELECT COUNT(1) FROM profiles WHERE profile_name = @profile_name;"
    Const PROFILE_ADD = "INSERT INTO profiles(profile_name) VALUES (@profile_name) RETURNING profile_id;"
    Const PROFILE_NAME_PARAMETER = "@profile_name"

    Public ReadOnly Property Profiles As IProfileStore Implements IDataStore.Profiles
        Get
            Return New ProfileStore(connection)
        End Get
    End Property

    Public Sub Open(connectionString As String) Implements IDataStore.Open
        connection = New MySqlConnection(connectionString)
        connection.Open()
    End Sub

    Public Sub Close() Implements IDataStore.Close
        connection.Close()
        connection = Nothing
    End Sub
End Class
