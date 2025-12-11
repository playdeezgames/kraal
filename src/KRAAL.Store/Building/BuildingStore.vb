Imports MySqlConnector

Friend Class BuildingStore
    Implements IBuildingStore

    Private connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function Create(faction As IFaction, buildingName As String) As IBuilding Implements IBuildingStore.Create
        Dim buildingId = CInt(connection.Create(
            TABLE_BUILDINGS,
            {
                (COLUMN_FACTION_ID, faction.FactionId),
                (COLUMN_BUILDING_NAME, buildingName)
            },
            COLUMN_BUILDING_ID))
        Return New Building(buildingId, buildingName)
    End Function
End Class
