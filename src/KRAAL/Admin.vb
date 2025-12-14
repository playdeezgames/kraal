Imports KRAAL.Domain
Imports Spectre.Console

Friend Module Admin
    Friend Sub Run(profiles As IProfiles)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Admin")
                            End Sub)
    End Sub
End Module
