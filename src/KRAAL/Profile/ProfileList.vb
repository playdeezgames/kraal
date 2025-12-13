Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileList
    Sub Run(profiles As IProfiles)
        Menu.Run(
            "Quit",
            Sub(choices, quit)
                Dim allProfiles = profiles.All
                choices.Add(
                                    New Choice("(new profile)", Sub() ProfileAdd.Run(profiles))
                                )
                choices.AddRange(allProfiles.Select(Function(x) New Choice(x.ProfileName, Sub() ProfileDetail.Run(x))))
            End Sub)
    End Sub
End Module
