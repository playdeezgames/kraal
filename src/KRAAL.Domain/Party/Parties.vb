Imports TGGD.Persistence

Friend Class Parties
    Implements IParties

    Private ReadOnly store As IStore
    Private ReadOnly universeId As Integer

    Public Sub New(store As IStore, universeId As Integer)
        Me.store = store
        Me.universeId = universeId
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IParty) Implements IParties.All
        Get
            Return store.GetRecords(Of IParty)(
                TABLE_PARTIES,
                {COLUMN_PARTY_ID},
                {(COLUMN_UNIVERSE_ID, universeId)},
                Function(x) New Party(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function Create() As IParty Implements IParties.Create
        Return New Party(
            store,
            CInt(store.Create(
                TABLE_PARTIES,
                {
                    (COLUMN_UNIVERSE_ID, universeId)
                },
                COLUMN_PARTY_ID)))
    End Function
End Class
