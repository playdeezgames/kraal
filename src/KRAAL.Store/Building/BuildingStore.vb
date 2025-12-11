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

    Public Function CountForFaction(faction As IFaction) As Integer Implements IBuildingStore.CountForFaction
        Return connection.GetCount(
            TABLE_BUILDINGS,
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            })
    End Function

    Public Function AllForFaction(faction As IFaction) As IEnumerable(Of IBuilding) Implements IBuildingStore.AllForFaction
        Return connection.GetList(Of IBuilding)(
            TABLE_BUILDINGS,
            {
                COLUMN_BUILDING_ID,
                COLUMN_BUILDING_NAME
            },
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            },
            COLUMN_BUILDING_NAME,
            Function(reader) New Building(reader.GetInt32(0), reader.GetString(1)))
    End Function
End Class
