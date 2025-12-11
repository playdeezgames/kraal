Public Interface IBuildingStore
    Function Create(faction As IFaction, buildingName As String) As IBuilding
    Function CountForFaction(faction As IFaction) As Integer
    Function AllForFaction(faction As IFaction) As IEnumerable(Of IBuilding)
End Interface
