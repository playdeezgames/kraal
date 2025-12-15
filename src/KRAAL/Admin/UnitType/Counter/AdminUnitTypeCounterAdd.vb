Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminUnitTypeCounterAdd
    Friend Sub Run(unitTypeCounters As IUnitTypeCounters)
        Menu.Run(
            "Go Back",
            Sub(choices, quit)
                AnsiConsole.MarkupLine($"Available Counter Types:")
                choices.AddRange(unitTypeCounters.AvailableCounterTypes.Select(Function(x) New Choice(x.CounterTypeName, AddUnitTypeCounter(unitTypeCounters, x))))
            End Sub)
    End Sub

    Private Function AddUnitTypeCounter(unitTypeCounters As IUnitTypeCounters, counterType As ICounterType) As Action
        Return Sub()
                   AnsiConsole.MarkupLine($"Set Counter Type {counterType.CounterTypeName} for Unit Type {unitTypeCounters.UnitType.UnitTypeName}:")
                   Dim minimum = AnsiConsole.Ask(Of Integer)("[olive]Minimum Value:[/]")
                   Dim maximum = Math.Max(AnsiConsole.Ask("[olive]Maximum Value:[/]", minimum), minimum)
                   Dim initial = Math.Clamp(AnsiConsole.Ask(Of Integer)("[olive]Initial Value:[/]"), minimum, maximum)
                   AdminUnitTypeCounterDetail.Run(unitTypeCounters.Create(counterType, initial, minimum, maximum))
               End Sub
    End Function
End Module
