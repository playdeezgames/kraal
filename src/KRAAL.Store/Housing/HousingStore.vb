Imports MySqlConnector

Friend Class HousingStore
    Implements IHousingStore

    Private connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function Create(building As IBuilding) As IHousing Implements IHousingStore.Create
        Dim housingId = CInt(connection.Create(
            TABLE_HOUSINGS,
            {
                (COLUMN_BUILDING_ID, building.BuildingId)
            },
            COLUMN_HOUSING_ID))
        Return New Housing(housingId)
    End Function
End Class
