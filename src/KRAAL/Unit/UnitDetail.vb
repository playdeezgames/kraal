Imports KRAAL.Store
Imports Spectre.Console

Friend Module UnitDetail
    Friend Sub Run(dataStore As IDataStore, unit As IUnit)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Unit Id: {unit.UnitId}")
            AnsiConsole.MarkupLine($"Unit Name: {unit.UnitName}")
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
