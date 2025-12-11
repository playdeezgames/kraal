Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionUnitList
    Friend Sub Run(dataStore As IDataStore, faction As IFaction)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Units for faction `{faction.FactionName}`")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False)
                       }
            For Each unit In dataStore.Units.AllForFaction(faction)
                choices.Add(New Choice(unit.UniqueName(), Sub() UnitDetail.Run(dataStore, unit)))
            Next
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
