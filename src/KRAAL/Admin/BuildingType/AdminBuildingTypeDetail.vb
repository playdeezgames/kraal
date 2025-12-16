Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminBuildingTypeDetail
    Friend Sub Run(buildingType As IBuildingType)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Building Type Id: {buildingType.buildingTypeId}")
                                AnsiConsole.MarkupLine($"Building Type Name: {buildingType.BuildingTypeName}")
                                choices.Add(New Choice("Rename...", Sub() AdminBuildingTypeRename.Run(buildingType)))
                                choices.Add(New Choice("Remove...", Sub() AdminBuildingTypeRemove.Run(buildingType, quit)))
                            End Sub)
    End Sub
End Module
