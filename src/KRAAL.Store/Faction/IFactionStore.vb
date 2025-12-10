Public Interface IFactionStore
    Sub Remove(faction As IFaction)
    Function CountForProfile(profile As IProfile) As Integer
    Function DoesNameExist(profile As IProfile, factionName As String) As Boolean
    Function Create(profile As IProfile, factionName As String) As IFaction
    Function AllForProfile(profile As IProfile) As IEnumerable(Of IFaction)
End Interface
