Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileList
    Sub Run(profiles As IProfiles)
        Menu.Run(
            "Quit",
            Sub(choices, quit)
                Dim allProfiles = profiles.All
                choices.AddRange(allProfiles.Select(Function(x) New Choice(x.ProfileName, Sub() ProfileDetail.Run(x))))
                choices.Add(New Choice("(new profile)", Sub() ProfileAdd.Run(profiles)))
                choices.Add(New Choice("Admin...", Sub() Admin.Run(profiles)))
            End Sub)
    End Sub
End Module
