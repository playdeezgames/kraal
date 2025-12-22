Imports TGGD.Persistence

Friend Class StarXYZ
    Implements IXYZ

    Private ReadOnly store As IStore
    Private ReadOnly starId As Integer

    Public Sub New(store As IStore, starId As Integer)
        Me.store = store
        Me.starId = starId
    End Sub

    Public Property X As Double Implements IXYZ.X
        Get
            Return CDbl(store.GetColumnValue(TABLE_STARS, COLUMN_STAR_X, (COLUMN_STAR_ID, Compare.EQ, starId)))
        End Get
        Set(value As Double)
            store.SetColumnValue(TABLE_STARS, (COLUMN_STAR_X, value), (COLUMN_STAR_ID, Compare.EQ, starId))
        End Set
    End Property

    Public Property Y As Double Implements IXYZ.Y
        Get
            Return CDbl(store.GetColumnValue(TABLE_STARS, COLUMN_STAR_Y, (COLUMN_STAR_ID, Compare.EQ, starId)))
        End Get
        Set(value As Double)
            store.SetColumnValue(TABLE_STARS, (COLUMN_STAR_Y, value), (COLUMN_STAR_ID, Compare.EQ, starId))
        End Set
    End Property

    Public Property Z As Double Implements IXYZ.Z
        Get
            Return CDbl(store.GetColumnValue(TABLE_STARS, COLUMN_STAR_Z, (COLUMN_STAR_ID, Compare.EQ, starId)))
        End Get
        Set(value As Double)
            store.SetColumnValue(TABLE_STARS, (COLUMN_STAR_Z, value), (COLUMN_STAR_ID, Compare.EQ, starId))
        End Set
    End Property
End Class
