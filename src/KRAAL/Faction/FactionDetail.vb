Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionDetail
    Friend Sub Run(dataStore As IDataStore, faction As IFaction)
        Dim running As Boolean = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Faction Id: {faction.FactionId}")
            AnsiConsole.MarkupLine($"Faction Name: {faction.FactionName}")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False)
                       }
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
