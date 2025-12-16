Imports KRAAL.Domain
Imports Spectre.Console

Friend Module BuildingDetail
    Friend Sub Run(building As IBuilding)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Building: {building.UniqueName}")
                                AnsiConsole.MarkupLine($"Building Type: {building.BuildingType.BuildingTypeName}")
                                choices.Add(New Choice("Rename Building...", Sub() BuildingRename.Run(building)))
                                Dim housingCount = building.HousingCount
                                If housingCount > 0 Then
                                    AnsiConsole.MarkupLine($"Housing: {housingCount}")
                                    choices.Add(New Choice("Housing...", Sub() BuildingHousingList.Run(building)))
                                End If
                            End Sub)
    End Sub
End Module
