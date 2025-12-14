Imports KRAAL.Domain
Imports Spectre.Console

Friend Module CounterTypeList
    Friend Sub Run(counterTypes As ICounterTypes)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine("Counter Types:")
                                choices.AddRange(counterTypes.All.Select(Function(x) New Choice(x.CounterTypeName, Sub() CounterTypeDetail.Run(x))))
                                choices.Add(New Choice("(add counter type)", Sub() CounterTypeAdd.Run(counterTypes)))
                            End Sub)
    End Sub
End Module
