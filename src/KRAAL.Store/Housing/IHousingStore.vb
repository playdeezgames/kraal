Public Interface IHousingStore
    Function Create(building As IBuilding) As IHousing
    Function FindForUnit(unit As IUnit) As IHousing
End Interface
