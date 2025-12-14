Imports KRAAL.Domain
Imports Spectre.Console

Friend Module Admin
    Friend Sub Run(profiles As IProfiles)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Admin")
                                choices.Add(New Choice("Unit Types...", Sub() UnitTypeList.Run(profiles)))
                                choices.Add(New Choice("Counter Types...", Sub() CounterTypeList.Run(profiles)))
                            End Sub)
    End Sub
End Module
