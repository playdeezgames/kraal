Friend Class UnitDetail
    Implements IUnitDetailDTO
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
    Public ReadOnly Property HousingBuildingId As Integer? Implements IUnitDetailDTO.HousingBuildingId
    Public ReadOnly Property HousingBuildingName As String Implements IUnitDetailDTO.HousingBuildingName
    Public ReadOnly Property UnitId As Integer Implements IUnitDTO.UnitId
    Public ReadOnly Property UnitName As String Implements IUnitDTO.UnitName
    Public ReadOnly Property HousingId As Integer? Implements IUnitDetailDTO.HousingId
    Public ReadOnly Property FactionId As Integer Implements IFactionDTO.FactionId
    Public ReadOnly Property FactionName As String Implements IFactionDTO.FactionName
End Class
