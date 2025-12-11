Imports MySqlConnector

Friend Class UnitStore
    Implements IUnitStore

    Private ReadOnly connection As MySqlConnection

    Public Sub New(connection As MySqlConnection)
        Me.connection = connection
    End Sub

    Public Function CountForFaction(faction As IFaction) As Integer Implements IUnitStore.CountForFaction
        Return connection.GetCount(
            TABLE_UNITS,
            {
                (COLUMN_FACTION_ID, faction.FactionId)
            })
    End Function

    Public Function Create(faction As IFaction, unitName As String) As IUnit Implements IUnitStore.Create
        Dim unitId = CInt(connection.Create(TABLE_UNITS, {(COLUMN_UNIT_NAME, unitName), (COLUMN_FACTION_ID, faction.FactionId)}, COLUMN_UNIT_ID))
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
End Class
