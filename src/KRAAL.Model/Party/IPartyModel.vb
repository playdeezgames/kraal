Public Interface IPartyModel
    ReadOnly Property ID As Integer
    ReadOnly Property IsPlayerParty As Boolean
    Sub SetPlayerParty()
    ReadOnly Property Ships As IEnumerable(Of IShipModel)
End Interface
