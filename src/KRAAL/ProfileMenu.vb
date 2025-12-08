Imports Spectre.Console

Friend Module ProfileMenu
    Sub Run(dataStore As IDataStore)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            Dim profiles = dataStore.Profiles.All
            Dim choices As New List(Of Choice) From
            {
                New Choice("Quit", Sub() running = False),
                New Choice("(+)", AddProfile(dataStore))
            }
            choices.AddRange(profiles.Select(Function(x) New Choice(x.ProfileName, ShowProfile(dataStore, x))))
            Choice.Pick("[olive]Choose Profile:[/]", choices)
        Loop
    End Sub

    Private Function ShowProfile(dataStore As IDataStore, profile As IProfile) As Action
        Return Sub()
                   AnsiConsole.Clear()
                   AnsiConsole.MarkupLine($"Profile Id: {profile.ProfileId}")
                   AnsiConsole.MarkupLine($"Profile Name: {profile.ProfileName}")
                   Choice.Pause(String.Empty)
               End Sub
    End Function

    Private Function AddProfile(dataStore As IDataStore) As Action
        Return Sub()
                   Dim profileName = AnsiConsole.Ask(Of String)("[olive]Profile Name:[/]", String.Empty)
                   If String.IsNullOrWhiteSpace(profileName) Then
                       Return
                   End If
                   If dataStore.Profiles.DoesNameExist(profileName) Then
                       Choice.Pause($"[red]That profile name('{profileName}') exists already![/]")
                       Return
                   End If
                   Dim profile As IProfile = dataStore.Profiles.Create(profileName)
               End Sub
    End Function
End Module
