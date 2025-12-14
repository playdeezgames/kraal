Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileDetail
    Friend Sub Run(profile As IProfile)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Profile Id: {profile.ProfileId}")
                                AnsiConsole.MarkupLine($"Profile Name: {profile.ProfileName}")
                                Dim factionCount = profile.FactionCount
                                AnsiConsole.MarkupLine($"Factions: {factionCount}")
                                choices.AddRange(
                                   {
                                       New Choice("(new faction)", Sub() FactionAdd.Run(profile))
                                   })
                                For Each faction In profile.AllFactions
                                    choices.Add(New Choice($"Faction: {faction.FactionName}", Sub() FactionDetail.Run(faction)))
                                Next
                                choices.Add(New Choice("Profile Admin...", Sub() ProfileAdmin.Run(profile, quit)))
                            End Sub)
    End Sub
End Module
