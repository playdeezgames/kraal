Imports System.Security.Cryptography.X509Certificates
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
                choices.Add(New Choice("Change Initial Value...", ChangeInitialValue(unitTypeCounter)))
                choices.Add(New Choice("Change Minimum Value...", ChangeMinimumValue(unitTypeCounter)))
                choices.Add(New Choice("Change Maximum Value...", ChangeMaximumValue(unitTypeCounter)))
                choices.Add(New Choice("Remove...", Remove(unitTypeCounter, quit)))
            End Sub)
    End Sub

    Private Function Remove(unitTypeCounter As IUnitTypeCounter, quit As Action) As Action
        Return Sub()
                   If Choice.Confirm($"[red]Are you sure you want to remove {unitTypeCounter.CounterType.CounterTypeName} from {unitTypeCounter.UnitType.UnitTypeName}[/]") Then
                       unitTypeCounter.Remove()
                       quit()
                   End If
               End Sub
    End Function

    Private Function ChangeMaximumValue(unitTypeCounter As IUnitTypeCounter) As Action
        Return Sub()
                   Dim maximum = AnsiConsole.Ask("[olive]New Maximum:[/]", unitTypeCounter.MaximumValue)
                   unitTypeCounter.MaximumValue = Math.Max(maximum, unitTypeCounter.InitialValue)
               End Sub
    End Function

    Private Function ChangeMinimumValue(unitTypeCounter As IUnitTypeCounter) As Action
        Return Sub()
                   Dim minimum = AnsiConsole.Ask("[olive]New Minimum:[/]", unitTypeCounter.MinimumValue)
                   unitTypeCounter.MinimumValue = Math.Min(minimum, unitTypeCounter.InitialValue)
               End Sub
    End Function

    Private Function ChangeInitialValue(unitTypeCounter As IUnitTypeCounter) As Action
        Return Sub()
                   Dim initial = AnsiConsole.Ask("[olive]New Initial:[/]", unitTypeCounter.InitialValue)
                   unitTypeCounter.InitialValue = Math.Clamp(initial, unitTypeCounter.MinimumValue, unitTypeCounter.MaximumValue)
               End Sub
    End Function
End Module
