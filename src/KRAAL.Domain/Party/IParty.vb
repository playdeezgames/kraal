Public Interface IParty
    ReadOnly Property PartyId As Integer
    ReadOnly Property Universe As IUniverse
    Function CreateShip(shipName As String, shipX As Double, shipY As Double, shipZ As Double) As IShip
    ReadOnly Property Ships As IShips
End Interface
