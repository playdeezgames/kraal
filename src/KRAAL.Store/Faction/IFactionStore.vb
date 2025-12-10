Public Interface IFactionStore
    Function CountForProfile(profile As IProfile) As Integer
    Function DoesNameExist(profile As IProfile, factionName As String) As Boolean
    Function Create(profile As IProfile, factionName As String) As IFaction
End Interface
