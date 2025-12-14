Imports KRAAL.Domain

Friend Module CounterTypeRemove
    Friend Sub Run(counterType As ICounterType, quitParent As Action)
        If Choice.Confirm($"[red]Are you sure you want to remove counter type {counterType.CounterTypeName}?[/]") Then
            counterType.Remove()
            quitParent()
        End If
    End Sub
End Module
