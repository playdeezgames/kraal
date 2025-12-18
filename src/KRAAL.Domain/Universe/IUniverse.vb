Public Interface IUniverse
    ReadOnly Property UniverseId As Integer
    Property UniverseName As String
    ReadOnly Property Universes As IUniverses
    ReadOnly Property Stars As IStars
    ReadOnly Property Factions As IFactions
    Sub Remove()
End Interface
