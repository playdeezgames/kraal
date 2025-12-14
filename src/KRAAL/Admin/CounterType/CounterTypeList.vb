Imports KRAAL.Domain
Imports Spectre.Console

Friend Module CounterTypeList
    Friend Sub Run(profiles As IProfiles)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Counter Types:")
                            End Sub)
    End Sub
End Module
