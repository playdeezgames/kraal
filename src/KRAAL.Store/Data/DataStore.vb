Imports MySqlConnector

Public Class DataStore
    Implements IDataStore
    Private connection As MySqlConnection

    Public ReadOnly Property Profiles As IProfileStore Implements IDataStore.Profiles
        Get
            Return New ProfileStore(connection)
        End Get
    End Property

    Public ReadOnly Property Factions As IFactionStore Implements IDataStore.Factions
        Get
            Return New FactionStore(connection)
        End Get
    End Property

    Public ReadOnly Property Units As IUnitStore Implements IDataStore.Units
        Get
            Return New UnitStore(connection)
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
