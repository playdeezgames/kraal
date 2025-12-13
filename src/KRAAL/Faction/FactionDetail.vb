Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionDetail
    Friend Sub Run(faction As IFaction)
        Menu.Run(Sub(choices, quit)

                     AnsiConsole.MarkupLine($"Faction Id: {faction.FactionId}")
                     AnsiConsole.MarkupLine($"Faction Name: {faction.FactionName}")
                     choices.Add(New Choice("Remove Faction", Sub()
                                                                  If Choice.Confirm("[red]Are you sure you want to remove this faction?[/]") Then
                                                                      faction.Remove()
                                                                      quit()
                                                                  End If
                                                              End Sub))
                     If faction.UnitCount > 0 Then
                         choices.Add(New Choice("Units...", Sub() FactionUnitList.Run(faction)))
                     End If
                     If faction.BuildingCount > 0 Then
                         choices.Add(New Choice("Buildings...", Sub() FactionBuildingList.Run(faction)))
                     End If
                 End Sub)
    End Sub
End Module
