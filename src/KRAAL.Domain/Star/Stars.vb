Imports TGGD.Persistence

Friend Class Stars
    Implements IStars

    Private ReadOnly store As IStore
    Private ReadOnly universeId As Integer

    Public Sub New(store As IStore, universeId As Integer)
        Me.store = store
        Me.universeId = universeId
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IStar) Implements IStars.All
        Get
            Return store.LegacyGetRecords(Of IStar)(
                TABLE_STARS,
                {COLUMN_STAR_ID},
                {(COLUMN_UNIVERSE_ID, universeId)},
                Function(x) New Star(store, x.GetInt32(0)))
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements IStars.Count
        Get
            Return store.GetCount(
                TABLE_STARS,
                (COLUMN_UNIVERSE_ID, universeId))
        End Get
    End Property

    Public Function Create(
                          starName As String,
                          starX As Double,
                          starY As Double,
                          starZ As Double) As IStar Implements IStars.Create
        Return New Star(
            store,
            CInt(store.Create(
                TABLE_STARS,
                {
                    (COLUMN_STAR_NAME, starName),
                    (COLUMN_UNIVERSE_ID, universeId),
                    (COLUMN_STAR_X, starX),
                    (COLUMN_STAR_Y, starY),
                    (COLUMN_STAR_Z, starZ)
                },
                COLUMN_STAR_ID)))
    End Function
End Class
