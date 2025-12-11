Imports MySqlConnector

Friend Class UnitStore
    Implements IUnitStore

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Sub Remove(unit As IUnit) Implements IUnitStore.Remove
        connection.Delete(TABLE_UNITS, {(COLUMN_UNIT_ID, unit.UnitId)})
    End Sub

    Public Function CountForFaction(faction As IFaction) As Integer Implements IUnitStore.CountForFaction
        Return connection.GetCount(
            TABLE_UNITS,
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            })
    End Function

    Public Function Create(faction As IFaction, unitName As String, housing As IHousing) As IUnit Implements IUnitStore.Create
        Dim values As New List(Of (Column As String, Value As Object)) From
            {
                (COLUMN_UNIT_NAME, unitName),
                (COLUMN_FACTION_ID, faction.FactionId)
            }
        If housing IsNot Nothing Then
            values.Add((COLUMN_HOUSING_ID, housing.HousingId))
        End If
        Dim unitId = CInt(connection.Create(TABLE_UNITS, values, COLUMN_UNIT_ID))
        Return New Unit(unitId, unitName)
    End Function

    Public Function AllForFaction(faction As IFaction) As IEnumerable(Of IUnit) Implements IUnitStore.AllForFaction
        Return connection.GetList(Of IUnit)(
            TABLE_UNITS,
            {
                COLUMN_UNIT_ID,
                COLUMN_UNIT_NAME
            },
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            },
            COLUMN_UNIT_NAME,
            Function(reader) New Unit(reader.GetInt32(0), reader.GetString(1)))
    End Function

    Public Function GetDetail(unit As IUnit) As IUnitDetail Implements IUnitStore.GetDetail
        Return connection.GetList(Of IUnitDetail)(
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
            COLUMN_UNIT_ID, Function(reader) New UnitDetail(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2),
                reader.GetInt32(3),
                reader.GetString(4),
                reader.GetInt32(5),
                reader.GetString(6))).SingleOrDefault
    End Function
End Class
