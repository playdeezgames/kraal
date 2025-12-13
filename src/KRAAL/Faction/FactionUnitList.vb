Imports KRAAL.Domain
Imports KRAAL.Store
Imports Spectre.Console

Friend Module FactionUnitList
    Friend Sub Run(faction As IFaction)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Units for faction `{faction.FactionName}`")
                                For Each unit In faction.AllUnits
                                    choices.Add(New Choice(unit.UniqueName(), Sub() UnitDetail.Run(unit)))
                                Next
                            End Sub)
    End Sub
End Module
