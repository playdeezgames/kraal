Imports TGGD.Persistence

Public Class Universe
    Implements IUniverse
    Friend Sub New(store As IStore, universeId As Integer)
        Me.store = store
        Me.UniverseId = universeId
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
End Class
