Imports TGGD.Persistence

Friend Class ShipXYZ
    Implements IXYZ

    Private ReadOnly store As IStore
    Private ReadOnly shipId As Integer

    Public Sub New(store As IStore, shipId As Integer)
        Me.store = store
        Me.shipId = shipId
    End Sub

    Public Property X As Double Implements IXYZ.X
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_X, (COLUMN_SHIP_ID, Compare.EQ, shipId)))
        End Get
        Set(value As Double)
            store.SetColumnValue(TABLE_SHIPS, (COLUMN_SHIP_X, value), (COLUMN_SHIP_ID, Compare.EQ, shipId))
        End Set
    End Property

    Public Property Y As Double Implements IXYZ.Y
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_Y, (COLUMN_SHIP_ID, Compare.EQ, shipId)))
        End Get
        Set(value As Double)
            store.SetColumnValue(TABLE_SHIPS, (COLUMN_SHIP_Y, value), (COLUMN_SHIP_ID, Compare.EQ, shipId))
        End Set
    End Property

    Public Property Z As Double Implements IXYZ.Z
        Get
            Return CDbl(store.GetColumnValue(TABLE_SHIPS, COLUMN_SHIP_Z, (COLUMN_SHIP_ID, Compare.EQ, shipId)))
        End Get
        Set(value As Double)
            store.SetColumnValue(TABLE_SHIPS, (COLUMN_SHIP_Z, value), (COLUMN_SHIP_ID, Compare.EQ, shipId))
        End Set
    End Property
End Class
