Public Interface IFactionStore
    Sub Remove(faction As IFactionDTO)
    Function CountForProfile(profile As IProfileDTO) As Integer
    Function DoesNameExist(profile As IProfileDTO, factionName As String) As Boolean
    Function Create(profile As IProfileDTO, factionName As String) As IFactionDTO
    Function AllForProfile(profile As IProfileDTO) As IEnumerable(Of IFactionDTO)
End Interface
