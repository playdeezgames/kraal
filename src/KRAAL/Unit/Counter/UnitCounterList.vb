Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitCounterList
    Friend Sub Run(unitCounters As IUnitCounters)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Counters for Unit {unitCounters.Unit.UnitName}:")
                choices.AddRange(unitCounters.All.Select(Function(x) New Choice(x.CounterType.CounterTypeName, Sub() UnitCounterDetail.Run(x))))
            End Sub)
    End Sub
End Module
