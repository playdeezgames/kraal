Imports KRAAL.Domain

Friend Class StarModel
    Implements IStarModel
    Private star As IStar

    Public Sub New(star As IStar)
        Me.star = star
    End Sub

    Public ReadOnly Property Name As String Implements IStarModel.Name
        Get
            Return star.StarName
        End Get
    End Property
End Class
