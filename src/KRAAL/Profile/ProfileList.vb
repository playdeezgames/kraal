Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileList
    Sub Run(profiles As IProfiles)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            Dim allProfiles = profiles.All
            Dim choices As New List(Of Choice) From
            {
                New Choice("Quit", Sub() running = False),
                New Choice("(new profile)", Sub() ProfileAdd.Run(profiles))
            }
            choices.AddRange(allProfiles.Select(Function(x) New Choice(x.ProfileName, Sub() ProfileDetail.Run(x))))
            Choice.Pick("[olive]Choose Profile:[/]", choices)
        Loop
    End Sub
End Module
