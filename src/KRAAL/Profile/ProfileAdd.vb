Imports KRAAL.Store
Imports Spectre.Console

Friend Module ProfileAdd
    Friend Sub Run(dataStore As IDataStore)
        Dim profileName = AnsiConsole.Ask("[olive]Profile Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(profileName) Then
            Return
        End If
        If dataStore.Profiles.DoesNameExist(profileName) Then
            Choice.Pause($"[red]That profile name('{profileName}') exists already![/]")
            Return
        End If
        ProfileDetail.Run(dataStore, dataStore.Profiles.Create(profileName))
    End Sub
End Module
