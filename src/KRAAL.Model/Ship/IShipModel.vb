Public Interface IShipModel
    ReadOnly Property Name As String
    ReadOnly Property Position As IXYZModel
    ReadOnly Property NearbyStars As IEnumerable(Of IStarModel)
End Interface
