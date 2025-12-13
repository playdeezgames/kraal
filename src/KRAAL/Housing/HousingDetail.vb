Imports KRAAL.Domain
Imports Spectre.Console

Friend Module HousingDetail
    Friend Sub Run(housing As IHousing)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Housing: {housing.UniqueName}")
                Dim unit = housing.Unit
                If unit IsNot Nothing Then
                    AnsiConsole.MarkupLine($"Unit: {unit.UniqueName}")
                Else
                    AnsiConsole.MarkupLine($"Unit: None")
                    If housing.Building.Faction.HasUnhousedUnits Then
                        choices.Add(New Choice("Assign To Unit...", Sub() Return))
                    End If
                End If
            End Sub)
    End Sub
End Module
