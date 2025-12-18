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

    Public ReadOnly Property Position As (X As Double, Y As Double, Z As Double) Implements IStarModel.Position
        Get
            Return (star.StarX, star.StarY, star.StarZ)
        End Get
    End Property
End Class
