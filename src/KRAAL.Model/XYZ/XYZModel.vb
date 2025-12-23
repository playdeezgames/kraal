Imports TGGD.Persistence

Friend Class XYZModel
    Implements IXYZModel

    Private ReadOnly xyz As IXYZ

    Public Sub New(xyz As IXYZ)
        Me.xyz = xyz
    End Sub

    Public ReadOnly Property X As Double Implements IXYZModel.X
        Get
            Return xyz.X
        End Get
    End Property

    Public ReadOnly Property Y As Double Implements IXYZModel.Y
        Get
            Return xyz.Y
        End Get
    End Property

    Public ReadOnly Property Z As Double Implements IXYZModel.Z
        Get
            Return xyz.Z
        End Get
    End Property

    Public Function DistanceTo(other As IXYZModel) As Double Implements IXYZModel.DistanceTo
        Return Math.Pow(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2), 0.5)
    End Function

    Public Function HeadingTo(other As IXYZModel) As IHeadingModel Implements IXYZModel.HeadingTo
        Dim deltaX = other.X - X
        Dim deltaY = other.Y - Y
        Dim deltaZ = other.Z - Z
        Dim theta = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI
        Dim phi = Math.Atan2(deltaZ, Math.Pow(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2), 0.5))
        Return New HeadingModel(theta, phi)
    End Function
End Class
