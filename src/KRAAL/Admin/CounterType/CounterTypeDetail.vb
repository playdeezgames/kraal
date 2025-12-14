Imports KRAAL.Domain
Imports Spectre.Console

Friend Module CounterTypeDetail
    Friend Sub Run(counterType As ICounterType)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Counter Type Id: {counterType.CounterTypeId}")
                                AnsiConsole.MarkupLine($"Counter Type Name: {counterType.CounterTypeName}")
                                choices.Add(New Choice("Rename...", Sub() CounterTypeRename.Run(counterType)))
                                choices.Add(New Choice("Remove...", Sub() CounterTypeRemove.Run(counterType, quit)))
                            End Sub)
    End Sub
End Module
