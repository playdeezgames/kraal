Public Interface IParties
    ReadOnly Property All As IEnumerable(Of IParty)
    Function Create() As IParty
End Interface
