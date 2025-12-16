Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminBuildingTypeList
    Friend Sub Run(buildingTypes As IBuildingTypes)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Building Types:")
                                choices.AddRange(buildingTypes.All.Select(Function(x) New Choice(x.BuildingTypeName, Sub() AdminBuildingTypeDetail.Run(x))))
                                choices.Add(New Choice("(add building type)", Sub() AdminBuildingTypeAdd.Run(buildingTypes)))
                            End Sub)
    End Sub
End Module
