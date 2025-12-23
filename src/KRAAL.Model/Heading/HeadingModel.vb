Friend Class HeadingModel
    Implements IHeadingModel
    Sub New(theta As Double, phi As Double)
        Me.Theta = theta
        Me.Phi = phi
    End Sub

    Public ReadOnly Property Theta As Double Implements IHeadingModel.Theta

    Public ReadOnly Property Phi As Double Implements IHeadingModel.Phi
End Class
