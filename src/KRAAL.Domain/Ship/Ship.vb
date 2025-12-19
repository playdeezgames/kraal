Imports TGGD.Persistence

Friend Class Ship
    Implements IShip

    Private ReadOnly store As IStore

    Public Sub New(store As IStore, shipId As Integer)
        Me.store = store
        Me.ShipId = shipId
    End Sub

    Public ReadOnly Property ShipId As Integer Implements IShip.ShipId

    Public Property ShipName As String Implements IShip.ShipName
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property
End Class
