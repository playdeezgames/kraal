Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionBuildingList
    Friend Sub Run(dataStore As IDataStore, faction As IFactionDTO)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Buildings for faction `{faction.FactionName}`")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False)
                       }
            For Each building In dataStore.Buildings.AllForFaction(faction)
                choices.Add(New Choice(building.UniqueName(), Sub() BuildingDetail.Run(dataStore, building)))
            Next
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
