Public Interface IParty
    ReadOnly Property PartyId As Integer
    ReadOnly Property Universe As IUniverse
    Function CreateShip(shipName As String) As IShip
    ReadOnly Property Ships As IShips
End Interface
