Imports KRAAL.Store
Imports Spectre.Console

Friend Module ProfileList
    Sub Run(dataStore As IDataStore)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            Dim profiles = dataStore.Profiles.All
            Dim choices As New List(Of Choice) From
            {
                New Choice("Quit", Sub() running = False),
                New Choice("(new profile)", Sub() ProfileAdd.Run(dataStore))
            }
            choices.AddRange(profiles.Select(Function(x) New Choice(x.ProfileName, Sub() ProfileDetail.Run(dataStore, x))))
            Choice.Pick("[olive]Choose Profile:[/]", choices)
        Loop
    End Sub
End Module
