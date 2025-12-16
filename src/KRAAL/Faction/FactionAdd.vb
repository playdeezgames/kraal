Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionAdd
    ReadOnly unitNames As String() = {"Moe", "Larry", "Curly"}
    Friend Sub Run(profile As IProfile)
        Dim factionName = AnsiConsole.Ask("[olive]Faction Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(factionName) Then
            Return
        End If
        If profile.DoesFactionNameExist(factionName) Then
            Choice.Pause($"[red]That faction name('{factionName}') exists already![/]")
            Return
        End If
        Dim faction = profile.CreateFaction(factionName)
        Dim building = faction.CreateBuilding("Dormitory")
        Dim housings = Enumerable.
            Range(0, 5).
            Select(Function(x) building.CreateHousing()).ToList
        Dim unitType = profile.Profiles.UnitTypes.FindByName(UNITTYPE_PEASANT)
        Dim unitTypeCounters = unitType.Counters.All
        For Each unitName In unitNames
            Dim housing = housings.FirstOrDefault
            Dim unit = faction.CreateUnit(unitName, unitType, housing)
            For Each counter In unitTypeCounters
                unit.Counters.Create(counter.CounterType, counter.InitialValue)
            Next
            If housing IsNot Nothing Then
                housings.Remove(housing)
            End If
        Next
        FactionDetail.Run(faction)
    End Sub
End Module
