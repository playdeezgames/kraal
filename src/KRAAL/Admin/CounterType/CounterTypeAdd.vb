Imports KRAAL.Domain
Imports Spectre.Console

Friend Module CounterTypeAdd
    Friend Sub Run(counterTypes As ICounterTypes)
        Dim name = AnsiConsole.Ask("[olive]New Counter Type Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(name) Then
            Return
        End If
        If counterTypes.DoesNameExist(name) Then
            Choice.Pause("[red]That Counter Type name already exists![/]")
            Return
        End If
        CounterTypeDetail.Run(counterTypes.Create(name))
    End Sub
End Module
