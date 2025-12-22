Imports TGGD.Persistence

Friend Class Faction
    Implements IFaction

    Private ReadOnly store As IStore

    Public Sub New(store As IStore, factionId As Integer)
        Me.store = store
        Me.factionId = factionId
    End Sub

    Public Property FactionName As String Implements IFaction.FactionName
        Get
            Return CStr(store.GetColumnValue(TABLE_FACTIONS, COLUMN_FACTION_NAME, (COLUMN_FACTION_ID, FactionId)))
        End Get
        Set(value As String)
            store.SetColumnValue(TABLE_FACTIONS, (COLUMN_FACTION_NAME, value), (COLUMN_FACTION_NAME, Compare.EQ, FactionId))
        End Set
    End Property

    Public ReadOnly Property FactionId As Integer Implements IFaction.FactionId
End Class
