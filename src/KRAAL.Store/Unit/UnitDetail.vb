Friend Class UnitDetail
    Implements IUnitDetail
    Sub New(
           unitId As Integer,
           unitName As String,
           housingId As Integer?,
           housingBuildingId As Integer?,
           housingBuildingName As String,
           factionId As Integer,
           factionName As String)
        Me.UnitId = unitId
        Me.UnitName = unitName
        Me.HousingId = housingId
        Me.HousingBuildingId = housingBuildingId
        Me.HousingBuildingName = housingBuildingName
        Me.FactionId = factionId
        Me.FactionName = factionName
    End Sub
    Public ReadOnly Property HousingBuildingId As Integer? Implements IUnitDetail.HousingBuildingId
    Public ReadOnly Property HousingBuildingName As String Implements IUnitDetail.HousingBuildingName
    Public ReadOnly Property UnitId As Integer Implements IUnit.UnitId
    Public ReadOnly Property UnitName As String Implements IUnit.UnitName
    Public ReadOnly Property HousingId As Integer? Implements IUnitDetail.HousingId
    Public ReadOnly Property FactionId As Integer Implements IFaction.FactionId
    Public ReadOnly Property FactionName As String Implements IFaction.FactionName
End Class
