Imports System.IO
Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionAdd
    ReadOnly unitNames As String() = {"Moe", "Larry", "Curly"}
    Friend Sub Run(dataStore As IDataStore, profile As IProfileDTO)
        Dim factionName = AnsiConsole.Ask("[olive]Faction Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(factionName) Then
            Return
        End If
        If dataStore.Factions.DoesNameExist(profile, factionName) Then
            Choice.Pause($"[red]That faction name('{factionName}') exists already![/]")
            Return
        End If
        Dim faction = dataStore.Factions.Create(profile, factionName)
        Dim building As IBuildingDTO = dataStore.Buildings.Create(faction, "Dormitory")
        Dim housings = Enumerable.
            Range(0, 5).
            Select(Function(x) dataStore.Housings.Create(building)).ToList
        For Each unitName In unitNames
            Dim housing = housings.FirstOrDefault
            dataStore.Units.Create(faction, unitName, housing)
            If housing IsNot Nothing Then
                housings.Remove(housing)
            End If
        Next
        FactionDetail.Run(dataStore, faction)
    End Sub
End Module
