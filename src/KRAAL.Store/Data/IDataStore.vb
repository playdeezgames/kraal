Public Interface IDataStore
    Sub Open(connectionString As String)
    Sub Close()
    ReadOnly Property Profiles As IProfileStore
    ReadOnly Property Factions As IFactionStore
End Interface
