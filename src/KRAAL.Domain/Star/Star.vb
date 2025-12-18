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
                (COLUMN_STAR_ID, StarId))
        End Set
    End Property

    Public ReadOnly Property StarId As Integer Implements IStar.StarId
End Class
