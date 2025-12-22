Public Interface IShipModel
    ReadOnly Property Name As String
    ReadOnly Property Position As (X As Double, Y As Double, Z As Double)
    ReadOnly Property NearbyStars As IEnumerable(Of IStarModel)
End Interface
