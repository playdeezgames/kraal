Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionDetail
    Friend Sub Run(faction As IFaction)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Faction Id: {faction.FactionId}")
                                AnsiConsole.MarkupLine($"Faction Name: {faction.FactionName}")
                                If faction.UnitCount > 0 Then
                                    choices.Add(New Choice("Units...", Sub() FactionUnitList.Run(faction)))
                                End If
                                If faction.BuildingCount > 0 Then
                                    choices.Add(New Choice("Buildings...", Sub() FactionBuildingList.Run(faction)))
                                End If
                                choices.Add(New Choice("Faction Admin...", Sub() FactionAdmin.Run(faction, quit)))
                            End Sub)
    End Sub
End Module
