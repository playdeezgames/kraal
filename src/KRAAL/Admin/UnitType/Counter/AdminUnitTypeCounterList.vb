Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminUnitTypeCounterList
    Friend Sub Run(unitTypeCounters As IUnitTypeCounters)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Unit Type {unitTypeCounters.UnitType.UnitTypeName} counters:")
                choices.AddRange(unitTypeCounters.All.Select(Function(x) New Choice(x.CounterType.CounterTypeName, Sub() AdminUnitTypeCounterDetail.Run(x))))
                choices.Add(New Choice("(new counter)", Sub() AdminUnitTypeCounterAdd.Run(unitTypeCounters)))
            End Sub)
    End Sub
End Module
