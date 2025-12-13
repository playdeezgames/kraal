Imports KRAAL.Domain
Imports Spectre.Console

Friend Module BuildingHousingList
    Friend Sub Run(building As IBuilding)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Housing within {building.UniqueName}")
                                choices.AddRange(building.Housings.Select(Function(x) New Choice(Describe(x), Sub() HousingDetail.Run(x))))
                            End Sub)
    End Sub

    Private Function Describe(housing As IHousing) As String
        Dim unit = housing.Unit
        Return $"{housing.UniqueName}{If(unit IsNot Nothing, $"(houses {unit.UniqueName})", $"(empty)")}"
    End Function
End Module
