Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminUnitTypeCounterDetail
    Friend Sub Run(unitTypeCounter As IUnitTypeCounter)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Unit Type: {unitTypeCounter.UnitType.UnitTypeName}")
                AnsiConsole.MarkupLine($"Counter Type: {unitTypeCounter.CounterType.CounterTypeName}")
                AnsiConsole.MarkupLine($"Initial: {unitTypeCounter.InitialValue}")
                AnsiConsole.MarkupLine($"Minimum: {unitTypeCounter.MinimumValue}")
                AnsiConsole.MarkupLine($"Maximum: {unitTypeCounter.MaximumValue}")
            End Sub)
    End Sub
End Module
