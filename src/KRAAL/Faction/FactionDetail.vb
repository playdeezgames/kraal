Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionDetail
    Friend Sub Run(faction As IFaction)
        Dim running As Boolean = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Faction Id: {faction.FactionId}")
            AnsiConsole.MarkupLine($"Faction Name: {faction.FactionName}")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False),
                           New Choice("Remove Faction", Sub()
                                                            If Choice.Confirm("[red]Are you sure you want to remove this faction?[/]") Then
                                                                faction.Remove()
                                                                running = False
                                                            End If
                                                        End Sub)
                       }
            If faction.UnitCount > 0 Then
                choices.Add(New Choice("Units...", Sub() FactionUnitList.Run(faction)))
            End If
            If faction.BuildingCount > 0 Then
                choices.Add(New Choice("Buildings...", Sub() FactionBuildingList.Run(faction)))
            End If
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
