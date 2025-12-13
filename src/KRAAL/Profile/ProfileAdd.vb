Imports KRAAL.Domain
Imports KRAAL.Store
Imports Spectre.Console

Friend Module ProfileAdd
    Friend Sub Run(profiles As IProfiles)
        Dim profileName = AnsiConsole.Ask("[olive]Profile Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(profileName) Then
            Return
        End If
        If profiles.DoesProfileNameExist(profileName) Then
            Choice.Pause($"[red]That profile name('{profileName}') exists already![/]")
            Return
        End If
        ProfileDetail.Run(profiles.CreateProfile(profileName))
    End Sub
End Module
