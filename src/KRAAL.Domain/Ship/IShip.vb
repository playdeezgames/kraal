Imports TGGD.Persistence

Public Interface IShip
    ReadOnly Property ShipId As Integer
    Property ShipName As String
    ReadOnly Property ShipX As Double
    ReadOnly Property ShipY As Double
    ReadOnly Property ShipZ As Double
    ReadOnly Property XYZ As IXYZ
    Function GetNearbyStars(distance As Double) As IEnumerable(Of IStar)
End Interface
