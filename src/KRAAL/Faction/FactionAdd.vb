Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionAdd
    ReadOnly unitNames As String() = {"Moe", "Larry", "Curly"}
    Friend Sub Run(dataStore As IDataStore, profile As IProfile)
        Dim factionName = AnsiConsole.Ask("[olive]Faction Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(factionName) Then
            Return
        End If
        If dataStore.Factions.DoesNameExist(profile, factionName) Then
            Choice.Pause($"[red]That faction name('{factionName}') exists already![/]")
            Return
        End If
        Dim faction = dataStore.Factions.Create(profile, factionName)
        For Each unitName In unitNames
            dataStore.Units.Create(faction, unitName)
        Next
        FactionDetail.Run(dataStore, faction)
    End Sub
End Module
