Imports TGGD.Persistence

Friend Class Party
    Implements IParty

    Private ReadOnly store As IStore

    Public Sub New(store As IStore, partyId As Integer)
        Me.store = store
        Me.PartyId = partyId
    End Sub

    Public ReadOnly Property PartyId As Integer Implements IParty.PartyId
End Class
