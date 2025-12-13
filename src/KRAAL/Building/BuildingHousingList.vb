Imports KRAAL.Domain
Imports Spectre.Console

Friend Module BuildingHousingList
    Friend Sub Run(building As IBuilding)
        Menu.Run(Sub(choices, quit)
                     AnsiConsole.MarkupLine($"Housing within {building.UniqueName}")
                     choices.AddRange(building.Housings.Select(Function(x) New Choice(x.UniqueName, Sub() HousingDetail.Run(x))))
                 End Sub)
    End Sub
End Module
