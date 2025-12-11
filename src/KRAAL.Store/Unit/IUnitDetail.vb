Public Interface IUnitDetail
    Inherits IUnit
    Inherits IFaction
    ReadOnly Property HousingBuildingId As Integer?
    ReadOnly Property HousingBuildingName As String
    ReadOnly Property HousingId As Integer?
End Interface
