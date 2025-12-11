Public Interface IUnitDetailDTO
    Inherits IUnitDTO
    Inherits IFactionDTO
    ReadOnly Property HousingBuildingId As Integer?
    ReadOnly Property HousingBuildingName As String
    ReadOnly Property HousingId As Integer?
End Interface
