Imports System.Reflection.Metadata.Ecma335
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

    Public ReadOnly Property IsPlayerParty As Boolean Implements IPartyModel.IsPlayerParty
        Get
            Dim playerParty = party.Universe.PlayerParty
            Return playerParty IsNot Nothing AndAlso playerParty.PartyId = party.PartyId
        End Get
    End Property
End Class
