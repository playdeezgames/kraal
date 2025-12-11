Imports KRAAL.Store
Imports Spectre.Console

Friend Module ProfileDetail
    Friend Sub Run(dataStore As IDataStore, profile As IProfileDTO)
        Dim running As Boolean = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Profile Id: {profile.ProfileId}")
            AnsiConsole.MarkupLine($"Profile Name: {profile.ProfileName}")
            AnsiConsole.MarkupLine($"Factions: {dataStore.Factions.CountForProfile(profile)}")
            Dim factionCount = dataStore.Factions.CountForProfile(profile)
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False),
                           New Choice("(new faction)", Sub() FactionAdd.Run(dataStore, profile)),
                           New Choice("Remove Profile", Sub()
                                                            If Choice.Confirm("[red]Are you sure you want to remove this profile?[/]") Then
                                                                dataStore.Profiles.Remove(profile)
                                                                running = False
                                                            End If
                                                        End Sub)
                       }
            For Each faction In dataStore.Factions.AllForProfile(profile)
                choices.Add(New Choice($"Faction: {faction.FactionName}", Sub() FactionDetail.Run(dataStore, faction)))
            Next
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
