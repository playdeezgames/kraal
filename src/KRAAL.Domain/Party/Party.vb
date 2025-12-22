Imports TGGD.Persistence

Friend Class Party
    Implements IParty

    Private ReadOnly store As IStore

    Public Sub New(store As IStore, partyId As Integer)
        Me.store = store
        Me.PartyId = partyId
    End Sub

    Public ReadOnly Property PartyId As Integer Implements IParty.PartyId

    Public ReadOnly Property Universe As IUniverse Implements IParty.Universe
        Get
            Return New Universe(store, CInt(store.GetColumnValue(TABLE_PARTIES, COLUMN_UNIVERSE_ID, (COLUMN_PARTY_ID, PartyId))))
        End Get
    End Property

    Public ReadOnly Property Ships As IShips Implements IParty.Ships
        Get
            Return New Ships(store, PartyId)
        End Get
    End Property

    Public Function CreateShip(shipName As String, shipX As Double, shipY As Double, shipZ As Double) As IShip Implements IParty.CreateShip
        Return New Ship(
            store,
            CInt(store.Create(
                TABLE_SHIPS,
                {
                    (COLUMN_PARTY_ID, PartyId),
                    (COLUMN_SHIP_NAME, shipName),
                    (COLUMN_SHIP_X, shipX),
                    (COLUMN_SHIP_Y, shipY),
                    (COLUMN_SHIP_Z, shipZ)
                },
                COLUMN_SHIP_ID)))
    End Function
End Class
