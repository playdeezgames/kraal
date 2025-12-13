Imports KRAAL.Domain
Imports KRAAL.Store
Imports Spectre.Console

Friend Module UnitDetail
    Friend Sub Run(unit As IUnit)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Unit: {unit.UnitName}")
            If unit.HasHousing Then
                AnsiConsole.MarkupLine($"Housing: {unit.Housing.UniqueName}")
            Else
                AnsiConsole.MarkupLine($"Housing: None")
            End If
            AnsiConsole.MarkupLine($"Faction: {unit.Faction.FactionName}")
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            If unit.HasHousing Then
                choices.Add(New Choice("Unhouse", Sub() unit.Housing = Nothing))
            ElseIf unit.Faction.HasAvailableHousing Then
                choices.Add(New Choice("House...", Sub() UnitPickHousing.Run(unit)))
            End If
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
