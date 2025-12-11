Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionDetail
    Friend Sub Run(dataStore As IDataStore, faction As IFaction)
        Dim running As Boolean = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Faction Id: {faction.FactionId}")
            AnsiConsole.MarkupLine($"Faction Name: {faction.FactionName}")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False),
                           New Choice("Remove Faction", Sub()
                                                            dataStore.Factions.Remove(faction)
                                                            running = False
                                                        End Sub)
                       }
            If dataStore.Units.CountForFaction(faction) > 0 Then
                choices.Add(New Choice("Units...", Sub() FactionUnitList.Run(dataStore, faction)))
            End If
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
