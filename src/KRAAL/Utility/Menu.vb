Imports Spectre.Console

Friend Module Menu
    Friend Sub Run(goBackText As String, action As Action(Of List(Of Choice), Action))
        Dim running = True
        Do While running
            Dim choices As New List(Of Choice) From
                {
                    New Choice(goBackText, Sub() running = False)
                }
            AnsiConsole.Clear()
            action(choices, Sub() running = False)
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
