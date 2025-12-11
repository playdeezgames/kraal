Public Interface IHousingStore
    Function Create(building As IBuildingDTO) As IHousingDTO
    Function FindForUnit(unit As IUnitDTO) As IHousingDTO
End Interface
