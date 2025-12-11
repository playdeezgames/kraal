Imports KRAAL.Store
Imports Spectre.Console

Friend Module BuildingDetail
    Friend Sub Run(dataStore As IDataStore, building As IBuildingDTO)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Building Id: {building.BuildingId}")
            AnsiConsole.MarkupLine($"Building Name: {building.BuildingName}")
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
