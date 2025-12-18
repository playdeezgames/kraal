Imports KRAAL.Domain

Friend Class PartyModel
    Implements IPartyModel
    Private ReadOnly party As IParty

    Public Sub New(party As IParty)
        Me.party = party
    End Sub

    Public ReadOnly Property ID As Integer Implements IPartyModel.ID
        Get
            Return party.PartyId
        End Get
    End Property
End Class
