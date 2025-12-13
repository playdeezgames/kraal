Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileDetail
    Friend Sub Run(profile As IProfile)
        Menu.Run(Sub(choices, quit)
                     AnsiConsole.MarkupLine($"Profile Id: {profile.ProfileId}")
                     AnsiConsole.MarkupLine($"Profile Name: {profile.ProfileName}")
                     Dim factionCount = profile.FactionCount
                     AnsiConsole.MarkupLine($"Factions: {factionCount}")
                     choices.AddRange(
                       {
                           New Choice("(new faction)", Sub() FactionAdd.Run(profile)),
                           New Choice("Remove Profile", Sub()
                                                            If Choice.Confirm("[red]Are you sure you want to remove this profile?[/]") Then
                                                                profile.Remove()
                                                                quit()
                                                            End If
                                                        End Sub)
                       })
                     For Each faction In profile.AllFactions
                         choices.Add(New Choice($"Faction: {faction.FactionName}", Sub() FactionDetail.Run(faction)))
                     Next
                 End Sub)
    End Sub
End Module
