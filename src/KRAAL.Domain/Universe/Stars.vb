Imports TGGD.Persistence

Friend Class Stars
    Implements IStars

    Private ReadOnly store As IStore
    Private ReadOnly universeId As Integer

    Public Sub New(store As IStore, universeId As Integer)
        Me.store = store
        Me.universeId = universeId
    End Sub
End Class
