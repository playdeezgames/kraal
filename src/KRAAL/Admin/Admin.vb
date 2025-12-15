Imports KRAAL.Domain
Imports Spectre.Console

Friend Module Admin
    Friend Sub Run(profiles As IProfiles)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Admin")
                                choices.Add(New Choice("Unit Types...", Sub() AdminUnitTypeList.Run(profiles.UnitTypes)))
                                choices.Add(New Choice("Counter Types...", Sub() AdminCounterTypeList.Run(profiles.CounterTypes)))
                            End Sub)
    End Sub
End Module
