Public Interface IFactions
    ReadOnly Property All As IEnumerable(Of IFaction)
    ReadOnly Property Count As Integer
    Function Create(factionName As String) As IFaction
End Interface
