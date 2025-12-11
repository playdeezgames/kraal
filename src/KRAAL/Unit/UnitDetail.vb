Imports KRAAL.Store
Imports Spectre.Console

Friend Module UnitDetail
    Friend Sub Run(dataStore As IDataStore, unit As IUnit)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            Dim details = dataStore.Units.GetDetail(unit)
            AnsiConsole.MarkupLine($"Unit Id: {details.UnitId}")
            AnsiConsole.MarkupLine($"Unit Name: {details.UnitName}")
            AnsiConsole.MarkupLine($"Housing Id: {details.HousingId}")
            AnsiConsole.MarkupLine($"Building Id: {details.HousingBuildingId}")
            AnsiConsole.MarkupLine($"Building Name: {details.HousingBuildingName}")
            AnsiConsole.MarkupLine($"Faction Id: {details.FactionId}")
            AnsiConsole.MarkupLine($"Faction Name: {details.FactionName}")
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
