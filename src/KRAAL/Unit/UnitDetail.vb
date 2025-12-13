Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitDetail
    Friend Sub Run(unit As IUnit)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Unit: {unit.UnitName}")
                                If unit.HasHousing Then
                                    AnsiConsole.MarkupLine($"Housing: {unit.Housing.UniqueName}")
                                Else
                                    AnsiConsole.MarkupLine($"Housing: None")
                                End If
                                AnsiConsole.MarkupLine($"Faction: {unit.Faction.FactionName}")
                                If unit.HasHousing Then
                                    choices.Add(New Choice("Unhouse", Sub() unit.Housing = Nothing))
                                ElseIf unit.Faction.HasAvailableHousing Then
                                    choices.Add(New Choice("House...", Sub() UnitPickHousing.Run(unit)))
                                End If
                            End Sub)
    End Sub
End Module
