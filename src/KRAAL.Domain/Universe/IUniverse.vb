Public Interface IUniverse
    ReadOnly Property UniverseId As Integer
    Property UniverseName As String
    ReadOnly Property Universes As IUniverses
    ReadOnly Property Stars As IStars
    Sub Remove()
End Interface
