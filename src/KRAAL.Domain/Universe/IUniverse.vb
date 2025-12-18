Public Interface IUniverse
    ReadOnly Property UniverseId As Integer
    Property UniverseName As String
    ReadOnly Property Universes As IUniverses
    ReadOnly Property Stars As IStars
    ReadOnly Property Factions As IFactions
    ReadOnly Property Parties As IParties
    Property Player As IParty
    Sub Remove()
End Interface
