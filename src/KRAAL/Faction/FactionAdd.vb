Imports KRAAL.Domain
Imports KRAAL.Store
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
        For Each unitName In unitNames
            Dim housing = housings.FirstOrDefault
            faction.CreateUnit(unitName, housing)
            If housing IsNot Nothing Then
                housings.Remove(housing)
            End If
        Next
        FactionDetail.Run(faction)
    End Sub
End Module
