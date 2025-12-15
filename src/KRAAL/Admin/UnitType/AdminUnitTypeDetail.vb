Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminUnitTypeDetail
    Friend Sub Run(unitType As IUnitType)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Unit Type Id: {unitType.UnitTypeId}")
                                AnsiConsole.MarkupLine($"Unit Type Name: {unitType.UnitTypeName}")
                                choices.Add(New Choice("Counters...", Sub() AdminUnitTypeCounterList.Run(unitType.Counters)))
                                choices.Add(New Choice("Rename...", Sub() AdminUnitTypeRename.Run(unitType)))
                                choices.Add(New Choice("Remove...", Sub() AdminUnitTypeRemove.Run(unitType, quit)))
                            End Sub)
    End Sub
End Module
