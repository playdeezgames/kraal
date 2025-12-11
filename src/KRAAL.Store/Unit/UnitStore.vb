Imports MySqlConnector

Friend Class UnitStore
    Implements IUnitStore

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Sub Remove(unit As IUnitDTO) Implements IUnitStore.Remove
        connection.Delete(TABLE_UNITS, {(COLUMN_UNIT_ID, unit.UnitId)})
    End Sub

    Public Sub SetHousing(unit As IUnitDTO, housing As IHousingDTO) Implements IUnitStore.SetHousing
        connection.Update(
            TABLE_UNITS,
            {
                (COLUMN_HOUSING_ID, If(housing IsNot Nothing, CObj(housing.HousingId), DBNull.Value))
            },
            {
                (COLUMN_UNIT_ID, unit.UnitId)
            })
    End Sub

    Public Function CountForFaction(faction As IFactionDTO) As Integer Implements IUnitStore.CountForFaction
        Return connection.GetCount(
            TABLE_UNITS,
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            })
    End Function

    Public Function Create(faction As IFactionDTO, unitName As String, housing As IHousingDTO) As IUnitDTO Implements IUnitStore.Create
        Dim values As New List(Of (Column As String, Value As Object)) From
            {
                (COLUMN_UNIT_NAME, unitName),
                (COLUMN_FACTION_ID, faction.FactionId)
            }
        If housing IsNot Nothing Then
            values.Add((COLUMN_HOUSING_ID, housing.HousingId))
        End If
        Dim unitId = CInt(connection.Create(TABLE_UNITS, values, COLUMN_UNIT_ID))
        Return New UnitDTO(unitId, unitName)
    End Function

    Public Function AllForFaction(faction As IFactionDTO) As IEnumerable(Of IUnitDTO) Implements IUnitStore.AllForFaction
        Return connection.GetList(Of IUnitDTO)(
            TABLE_UNITS,
            {
                COLUMN_UNIT_ID,
                COLUMN_UNIT_NAME
            },
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            },
            COLUMN_UNIT_NAME,
            Function(reader, result) New UnitDTO(result.GetInt32(0), result.GetString(1)))
    End Function

    Public Function GetDetail(unit As IUnitDTO) As IUnitDetailDTO Implements IUnitStore.GetDetail
        Return connection.GetList(Of IUnitDetailDTO)(
            VIEW_UNIT_DETAILS,
            {
                COLUMN_UNIT_ID,
                COLUMN_UNIT_NAME,
                COLUMN_HOUSING_ID,
                COLUMN_HOUSING_BUILDING_ID,
                COLUMN_HOUSING_BUILDING_NAME,
                COLUMN_FACTION_ID,
                COLUMN_FACTION_NAME
            },
            {
                (COLUMN_UNIT_ID, unit.UnitId)
            },
            COLUMN_UNIT_ID, Function(reader, result) New UnitDetail(
                result.GetInt32(0),
                result.GetString(1),
                If(Not result.IsDBNull(2), result.GetInt32(2), CType(Nothing, Integer?)),
                If(Not result.IsDBNull(3), result.GetInt32(3), CType(Nothing, Integer?)),
                If(Not result.IsDBNull(4), result.GetString(4), Nothing),
                result.GetInt32(5),
                result.GetString(6))).SingleOrDefault
    End Function
End Class
