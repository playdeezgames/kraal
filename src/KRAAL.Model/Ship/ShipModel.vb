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
End Class
