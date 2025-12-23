Public Interface IXYZModel
    ReadOnly Property X As Double
    ReadOnly Property Y As Double
    ReadOnly Property Z As Double
    Function DistanceTo(other As IXYZModel) As Double
End Interface
