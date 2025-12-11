Public Interface IUnitStore
    Function Create(faction As IFactionDTO, unitName As String, housing As IHousingDTO) As IUnitDTO
    Function CountForFaction(faction As IFactionDTO) As Integer
    Function AllForFaction(faction As IFactionDTO) As IEnumerable(Of IUnitDTO)
    Sub Remove(unit As IUnitDTO)
    Function GetDetail(unit As IUnitDTO) As IUnitDetailDTO
    Sub SetHousing(unit As IUnitDTO, housing As IHousingDTO)
End Interface
