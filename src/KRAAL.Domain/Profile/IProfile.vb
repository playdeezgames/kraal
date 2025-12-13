Public Interface IProfile
    ReadOnly Property ProfileId As Integer
    Property ProfileName As String
    ReadOnly Property FactionCount As Integer
    Sub Remove()
    Function DoesFactionNameExist(factionName As String) As Boolean
    Function CreateFaction(factionName As String) As IFaction
    ReadOnly Property AllFactions As IEnumerable(Of IFaction)
End Interface
