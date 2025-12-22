Public Interface IStarModel
    ReadOnly Property Name As String
    ReadOnly Property LegacyPosition As (X As Double, Y As Double, Z As Double)
    ReadOnly Property Position As IXYZModel
End Interface
