Imports TGGD.Persistence

Friend Class Ships
    Implements IShips

    Private store As IStore
    Private partyId As Integer

    Public Sub New(store As IStore, partyId As Integer)
        Me.store = store
        Me.partyId = partyId
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IShip) Implements IShips.All
        Get
            Return store.GetRecords(Of IShip)(
                TABLE_SHIPS,
                {COLUMN_SHIP_ID},
                {(COLUMN_PARTY_ID, Compare.EQ, partyId)},
                Function(x) New Ship(store, x.GetInt32(0)))
        End Get
    End Property
End Class
