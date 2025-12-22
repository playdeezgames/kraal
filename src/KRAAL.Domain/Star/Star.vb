Imports TGGD.Persistence

Friend Class Star
    Implements IStar

    Private ReadOnly store As IStore

    Public Sub New(store As IStore, starId As Integer)
        Me.store = store
        Me.starId = starId
    End Sub

    Public Property StarName As String Implements IStar.StarName
        Get
            Return CStr(store.GetColumnValue(
                TABLE_STARS,
                COLUMN_STAR_NAME,
                (COLUMN_STAR_ID, StarId)))
        End Get
        Set(value As String)
            store.SetColumnValue(
                TABLE_STARS,
                (COLUMN_STAR_NAME, value),
                (COLUMN_STAR_ID, Compare.EQ, StarId))
        End Set
    End Property

    Public ReadOnly Property StarId As Integer Implements IStar.StarId

    Public ReadOnly Property StarX As Double Implements IStar.StarX
        Get
            Return CDbl(store.GetColumnValue(
                TABLE_STARS,
                COLUMN_STAR_X,
                (COLUMN_STAR_ID, StarId)))
        End Get
    End Property

    Public ReadOnly Property StarY As Double Implements IStar.StarY
        Get
            Return CDbl(store.GetColumnValue(
                TABLE_STARS,
                COLUMN_STAR_Y,
                (COLUMN_STAR_ID, StarId)))
        End Get
    End Property

    Public ReadOnly Property StarZ As Double Implements IStar.StarZ
        Get
            Return CDbl(store.GetColumnValue(
                TABLE_STARS,
                COLUMN_STAR_Z,
                (COLUMN_STAR_ID, StarId)))
        End Get
    End Property
End Class
