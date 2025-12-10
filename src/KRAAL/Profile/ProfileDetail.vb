Imports KRAAL.Store
Imports Spectre.Console

Friend Module ProfileDetail
    Friend Sub Run(dataStore As IDataStore, profile As IProfile)
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
                           New Choice("(new faction)", Sub() FactionAdd.Run(dataStore, profile))
                       }
            If factionCount < 1 Then
                choices.Add(New Choice("Remove Profile", Sub()
                                                             dataStore.Profiles.Remove(profile)
                                                             running = False
                                                         End Sub))
            End If
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
