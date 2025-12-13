Public Interface IFaction
    ReadOnly Property FactionId As Integer
    Property FactionName As String
    Sub Remove()
    Function CreateUnit(unitName As String, housing As IHousing) As IUnit
    Function CreateBuilding(buildingName As String) As IBuilding
    ReadOnly Property AllUnits As IEnumerable(Of IUnit)
    ReadOnly Property BuildingCount As Integer
    ReadOnly Property UnitCount As Integer
    ReadOnly Property AllBuildings As IEnumerable(Of IBuilding)
End Interface
