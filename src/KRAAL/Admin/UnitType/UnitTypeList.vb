Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitTypeList
    Friend Sub Run(unitTypes As IUnitTypes)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Unit Types:")
                                choices.AddRange(unitTypes.All.Select(Function(x) New Choice(x.UnitTypeName, Sub() UnitTypeDetail.Run(x))))
                                choices.Add(New Choice("(add unit type)", Sub() UnitTypeAdd.Run(unitTypes)))
                            End Sub)
    End Sub
End Module
