Imports TGGD.Persistence

Public Class Universe
    Implements IUniverse
    Friend Sub New(store As IStore, universeId As Integer)
        Me.store = store
        Me.UniverseId = universeId
    End Sub

    Public Sub Remove() Implements IUniverse.Remove
        store.Delete(TABLE_UNIVERSES, (COLUMN_UNIVERSE_ID, UniverseId))
    End Sub

    Private ReadOnly store As IStore
    Public ReadOnly Property UniverseId As Integer Implements IUniverse.UniverseId

    Public Property UniverseName As String Implements IUniverse.UniverseName
        Get
            Return CStr(store.GetColumnValue(TABLE_UNIVERSES, COLUMN_UNIVERSE_NAME, (COLUMN_UNIVERSE_ID, UniverseId)))
        End Get
        Set(value As String)
            store.SetColumnValue(TABLE_UNIVERSES, (COLUMN_UNIVERSE_NAME, value), (COLUMN_UNIVERSE_ID, UniverseId))
        End Set
    End Property

    Public ReadOnly Property Universes As IUniverses Implements IUniverse.Universes
        Get
            Return New Universes(store)
        End Get
    End Property

    Public ReadOnly Property Stars As IStars Implements IUniverse.Stars
        Get
            Return New Stars(store, UniverseId)
        End Get
    End Property

    Public ReadOnly Property Factions As IFactions Implements IUniverse.Factions
        Get
            Return New Factions(store, UniverseId)
        End Get
    End Property

    Public ReadOnly Property Parties As IParties Implements IUniverse.Parties
        Get
            Return New Parties(store, UniverseId)
        End Get
    End Property

    Public Property PlayerParty As IParty Implements IUniverse.PlayerParty
        Get
            Return New Party(store, CInt(store.GetColumnValue(TABLE_UNIVERSES, COLUMN_PARTY_ID, (COLUMN_UNIVERSE_ID, UniverseId))))
        End Get
        Set(value As IParty)
            store.SetColumnValue(TABLE_UNIVERSES, (COLUMN_PARTY_ID, value.PartyId), (COLUMN_UNIVERSE_ID, UniverseId))
        End Set
    End Property
End Class
