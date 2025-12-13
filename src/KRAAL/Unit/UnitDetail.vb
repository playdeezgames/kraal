Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitDetail
    Friend Sub Run(unit As IUnit)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Unit: {unit.UnitName}")
                                AnsiConsole.MarkupLine($"Faction: {unit.Faction.FactionName}")
                                choices.Add(New Choice("Rename Unit...", Sub() UnitRename.Run(unit)))
                                Dim housing = unit.Housing
                                If housing IsNot Nothing Then
                                    AnsiConsole.MarkupLine($"Housing: {unit.Housing.UniqueName}")
                                    choices.Add(New Choice("Housing...", Sub() HousingDetail.Run(housing)))
                                    choices.Add(New Choice("Unhouse", Sub() unit.Housing = Nothing))
                                Else
                                    AnsiConsole.MarkupLine($"Housing: None")
                                    choices.Add(New Choice("House...", Sub() UnitPickHousing.Run(unit)))
                                End If
                            End Sub)
    End Sub
End Module
