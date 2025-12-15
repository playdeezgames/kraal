Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminUnitTypeCounterList
    Friend Sub Run(unitType As IUnitType)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Unit Type {unitType.UnitTypeName} counters:")
                choices.AddRange(unitType.Counters.All.Select(Function(x) New Choice(x.CounterType.CounterTypeName, Sub() Return)))
            End Sub)
    End Sub
End Module
