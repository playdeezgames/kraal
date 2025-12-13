Imports KRAAL.Domain
Imports Spectre.Console

Friend Module BuildingDetail
    Friend Sub Run(building As IBuilding)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Building: {building.UniqueName}")
                                Dim housingCount = building.HousingCount
                                If housingCount > 0 Then
                                    AnsiConsole.MarkupLine($"Housing: {housingCount}")
                                    choices.Add(New Choice("Housing...", Sub() BuildingHousingList.Run(building)))
                                End If
                            End Sub)
    End Sub
End Module
