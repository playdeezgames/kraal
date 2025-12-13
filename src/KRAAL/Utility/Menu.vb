Imports Spectre.Console

Friend Module Menu
    Friend Sub Run(action As Action(Of List(Of Choice), Action))
        Dim running = True
        Do While running
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            AnsiConsole.Clear()
            action(choices, Sub() running = False)
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
