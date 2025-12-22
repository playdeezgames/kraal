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
            Return CStr(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_NAME, (COLUMN_SHIP_ID, ShipId)))
        End Get
        Set(value As String)
            store.SetColumnValue(TABLE_SHIPS, (COLUMN_SHIP_NAME, value), (COLUMN_SHIP_ID, ShipId))
        End Set
    End Property

    Public ReadOnly Property ShipX As Double Implements IShip.ShipX
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_X, (COLUMN_SHIP_ID, ShipId)))
        End Get
    End Property

    Public ReadOnly Property ShipY As Double Implements IShip.ShipY
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_Y, (COLUMN_SHIP_ID, ShipId)))
        End Get
    End Property

    Public ReadOnly Property ShipZ As Double Implements IShip.ShipZ
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_Z, (COLUMN_SHIP_ID, ShipId)))
        End Get
    End Property
End Class
