Public Interface IBuildingStore
    Function Create(faction As IFactionDTO, buildingName As String) As IBuildingDTO
    Function CountForFaction(faction As IFactionDTO) As Integer
    Function AllForFaction(faction As IFactionDTO) As IEnumerable(Of IBuildingDTO)
End Interface
