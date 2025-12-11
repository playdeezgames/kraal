Public Interface IDataStore
    Sub Open(connectionString As String)
    Sub Close()
    ReadOnly Property Profiles As IProfileStore
    ReadOnly Property Factions As IFactionStore
    ReadOnly Property Units As IUnitStore
    ReadOnly Property Buildings As IBuildingStore
    ReadOnly Property Housings As IHousingStore
End Interface
