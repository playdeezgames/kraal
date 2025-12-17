Public Interface IUniverse
    ReadOnly Property UniverseId As Integer
    Property UniverseName As String
    ReadOnly Property Universes As IUniverses
    Sub Remove()
End Interface
