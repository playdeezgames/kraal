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
                AnsiConsole.MarkupLine($"Building: {unit.Housing.Building.BuildingName}")
            Else
                AnsiConsole.MarkupLine($"Building: None")
            End If
            AnsiConsole.MarkupLine($"Faction: {unit.Faction.FactionName}")
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            If unit.HasHousing Then
                choices.Add(New Choice("Unhouse", Sub() unit.Housing = Nothing))
            End If
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
