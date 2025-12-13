Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionBuildingList
    Friend Sub Run(faction As IFaction)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Buildings for faction `{faction.FactionName}`")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False)
                       }
            For Each building In faction.AllBuildings
                choices.Add(New Choice(building.UniqueName(), Sub() BuildingDetail.Run(building)))
            Next
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
