Imports KRAAL.Domain

Friend Class ShipModel
    Implements IShipModel
    Private ReadOnly ship As IShip

    Public Sub New(ship As IShip)
        Me.ship = ship
    End Sub

    Public ReadOnly Property Name As String Implements IShipModel.Name
        Get
            Return ship.ShipName
        End Get
    End Property

    Public ReadOnly Property Position As (X As Double, Y As Double, Z As Double) Implements IShipModel.Position
        Get
            Return (ship.ShipX, ship.ShipY, ship.ShipZ)
        End Get
    End Property

    Public ReadOnly Property NearbyStars As IEnumerable(Of IStarModel) Implements IShipModel.NearbyStars
        Get
            Return ship.GetNearbyStars(DEFAULT_SCANNER_RANGE).Select(Function(x) New StarModel(x))
        End Get
    End Property
End Class
