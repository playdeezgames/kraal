Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitTypeList
    Friend Sub Run(profiles As IProfiles)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Unit Types:")
                            End Sub)
    End Sub
End Module
