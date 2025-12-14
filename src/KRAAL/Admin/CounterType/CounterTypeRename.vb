Imports KRAAL.Domain
Imports Spectre.Console

Friend Module CounterTypeRename
    Friend Sub Run(counterType As ICounterType)
        Dim name = AnsiConsole.Ask("[olive]New Name:[/]", counterType.CounterTypeName)
        If counterType.CounterTypes.DoesNameExist(name) Then
            Choice.Pause("[red]That name already exists![/]")
            Return
        End If
        counterType.CounterTypeName = name
    End Sub
End Module
