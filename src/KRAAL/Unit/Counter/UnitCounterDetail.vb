Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitCounterDetail
    Friend Sub Run(unitCounter As IUnitCounter)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Unit: {unitCounter.Unit.UnitName}")
                AnsiConsole.MarkupLine($"Counter Type: {unitCounter.CounterType.CounterTypeName}")
                AnsiConsole.MarkupLine($"Value: {unitCounter.CurrentValue}")
            End Sub)
    End Sub
End Module
