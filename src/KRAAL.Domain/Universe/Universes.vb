Imports TGGD.Persistence

Public Class Universes
    Implements IUniverses

    Private ReadOnly store As IStore

    Friend Sub New(store As IStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Count As Integer Implements IUniverses.Count
        Get
            Return store.GetCount(TABLE_UNIVERSES)
        End Get
    End Property

    Public ReadOnly Property All As IEnumerable(Of IUniverse) Implements IUniverses.All
        Get
            Return store.GetRecords(Of IUniverse)(
                TABLE_UNIVERSES,
                {COLUMN_UNIVERSE_ID},
                {},
                Function(x) New Universe(store, x.GetInt32(0)))
        End Get
    End Property

    Public Sub Export(filename As String) Implements IUniverses.Export
        store.Export(filename)
    End Sub

    Public Sub Import(filename As String) Implements IUniverses.Import
        store.Import(filename)
    End Sub

    Public Shared Function Create(store As IStore) As IUniverses
        Return New Universes(store)
    End Function

    Public Function FindByName(universeName As String) As Boolean Implements IUniverses.FindByName
        Return store.GetCount(TABLE_UNIVERSES, (COLUMN_UNIVERSE_NAME, universeName)) > 0
    End Function

    Public Function Create(universeName As String) As IUniverse Implements IUniverses.Create
        Return New Universe(store, CInt(store.Create(TABLE_UNIVERSES, {(COLUMN_UNIVERSE_NAME, universeName)}, COLUMN_UNIVERSE_ID)))
    End Function
End Class
