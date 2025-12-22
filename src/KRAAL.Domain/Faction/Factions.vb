Imports TGGD.Persistence

Friend Class Factions
    Implements IFactions

    Private ReadOnly store As IStore
    Private ReadOnly universeId As Integer

    Public Sub New(store As IStore, universeId As Integer)
        Me.store = store
        Me.universeId = universeId
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IFaction) Implements IFactions.All
        Get
            Return store.GetRecords(Of IFaction)(
                TABLE_FACTIONS,
                {COLUMN_FACTION_ID},
                {(COLUMN_UNIVERSE_ID, Compare.EQ, universeId)},
                Function(x) New Faction(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements IFactions.Count
        Get
            Return store.GetCount(
                TABLE_FACTIONS,
                (COLUMN_UNIVERSE_ID, Compare.EQ, universeId))
        End Get
    End Property

    Public Function Create(factionName As String) As IFaction Implements IFactions.Create
        Return New Faction(
            store,
            CInt(store.Create(
                TABLE_FACTIONS,
                {
                    (COLUMN_FACTION_NAME, factionName),
                    (COLUMN_UNIVERSE_ID, universeId)
                },
                COLUMN_FACTION_ID)))
    End Function
End Class
