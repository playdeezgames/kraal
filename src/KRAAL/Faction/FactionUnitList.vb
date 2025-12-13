Imports KRAAL.Domain
Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionUnitList
    Friend Sub Run(faction As IFaction)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Units for faction `{faction.FactionName}`")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False)
                       }
            For Each unit In faction.AllUnits
                choices.Add(New Choice(unit.UniqueName(), Sub() UnitDetail.Run(unit)))
            Next
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
