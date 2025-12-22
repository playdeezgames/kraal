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
End Class
