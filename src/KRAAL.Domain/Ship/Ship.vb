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
            Return CStr(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_NAME, (COLUMN_SHIP_ID, Compare.EQ, ShipId)))
        End Get
        Set(value As String)
            store.SetColumnValue(TABLE_SHIPS, (COLUMN_SHIP_NAME, value), (COLUMN_SHIP_ID, Compare.EQ, ShipId))
        End Set
    End Property

    Public ReadOnly Property ShipX As Double Implements IShip.ShipX
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_X, (COLUMN_SHIP_ID, Compare.EQ, ShipId)))
        End Get
    End Property

    Public ReadOnly Property ShipY As Double Implements IShip.ShipY
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_Y, (COLUMN_SHIP_ID, Compare.EQ, ShipId)))
        End Get
    End Property

    Public ReadOnly Property ShipZ As Double Implements IShip.ShipZ
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_Z, (COLUMN_SHIP_ID, Compare.EQ, ShipId)))
        End Get
    End Property

    Public ReadOnly Property XYZ As IXYZ Implements IShip.XYZ
        Get
            Return New ShipXYZ(store, ShipId)
        End Get
    End Property

    Public Function GetNearbyStars(distance As Double) As IEnumerable(Of IStar) Implements IShip.GetNearbyStars
        Return store.GetRecords(Of IStar)(
            VIEW_STAR_SHIP_DISTANCES,
            {COLUMN_STAR_ID},
            {
                (COLUMN_SHIP_ID, Compare.EQ, ShipId),
                (COLUMN_DISTANCE, Compare.LE, distance)
            },
            Function(x) New Star(store, x.GetInt32(0)))
    End Function
End Class
