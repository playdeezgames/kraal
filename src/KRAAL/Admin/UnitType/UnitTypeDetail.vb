Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitTypeDetail
    Friend Sub Run(unitType As IUnitType)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Unit Type Id: {unitType.UnitTypeId}")
                                AnsiConsole.MarkupLine($"Unit Type Name: {unitType.UnitTypeName}")
                                choices.Add(New Choice("Rename...", Sub() UnitTypeRename.Run(unitType)))
                                choices.Add(New Choice("Remove...", Sub() UnitTypeRemove.Run(unitType, quit)))
                            End Sub)
    End Sub
End Module
