Imports System.Reflection.Metadata.Ecma335
Imports MySqlConnector

Friend Class HousingStore
    Implements IHousingStore

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function Create(building As IBuildingDTO) As IHousingDTO Implements IHousingStore.Create
        Dim housingId = CInt(connection.Create(
            TABLE_HOUSINGS,
            {
                (COLUMN_BUILDING_ID, building.BuildingId)
            },
            COLUMN_HOUSING_ID))
        Return New HousingDTO(housingId)
    End Function

    Public Function FindForUnit(unit As IUnitDTO) As IHousingDTO Implements IHousingStore.FindForUnit
        Dim housingIds = connection.GetList(Of Integer)(
            TABLE_UNITS,
            {
                COLUMN_HOUSING_ID
            },
            {
                (COLUMN_UNIT_ID, unit.UnitId)
            },
            COLUMN_HOUSING_ID,
            Function(reader) reader.GetInt32(0))
        If Not housingIds.Any Then
            Return Nothing
        End If
        Return New HousingDTO(housingIds.Single)
    End Function
End Class
