Imports KRAAL.Domain
Imports KRAAL.Store
Imports Spectre.Console

Friend Module ProfileDetail
    Friend Sub Run(profile As IProfile)
        Dim running As Boolean = True
        Do While running
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Profile Id: {profile.ProfileId}")
            AnsiConsole.MarkupLine($"Profile Name: {profile.ProfileName}")
            Dim factionCount = profile.FactionCount
            AnsiConsole.MarkupLine($"Factions: {factionCount}")
            Dim choices As New List(Of Choice) From
                       {
                           New Choice("Go Back", Sub() running = False),
                           New Choice("(new faction)", Sub() FactionAdd.Run(profile)),
                           New Choice("Remove Profile", Sub()
                                                            If Choice.Confirm("[red]Are you sure you want to remove this profile?[/]") Then
                                                                profile.Remove()
                                                                running = False
                                                            End If
                                                        End Sub)
                       }
            For Each faction In profile.AllFactions
                choices.Add(New Choice($"Faction: {faction.FactionName}", Sub() FactionDetail.Run(faction)))
            Next
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
