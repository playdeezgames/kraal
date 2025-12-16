Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitNextTurn
    Friend Sub Run(unit As IUnit)
        ExposeUnit(unit)
        StarveUnit(unit, "starvation")
    End Sub

    Private Sub ExposeUnit(unit As IUnit)
        If unit.Exists AndAlso unit.Housing Is Nothing Then
            ReduceUnitHealth(unit, "exposure")
        End If
    End Sub

    Private Sub ReduceUnitHealth(unit As IUnit, reason As String)
        If unit.Exists Then
            Dim health = unit.Counters.FindByName(COUNTERTYPE_HEALTH)
            If health.CurrentValue > health.UnitTypeCounter.MinimumValue Then
                health.CurrentValue -= 1
                AnsiConsole.MarkupLine($"{unit.UniqueName} loses 1 {health.CounterType.CounterTypeName}({health.CurrentValue}) due to {reason}.")
            End If
            If health.CurrentValue = health.UnitTypeCounter.MinimumValue Then
                AnsiConsole.MarkupLine($"{unit.UniqueName} is dead due to {reason}.")
                unit.Remove()
            End If
        End If
    End Sub

    Private Sub StarveUnit(unit As IUnit, reason As String)
        If unit.Exists Then
            Dim satiety = unit.Counters.FindByName(COUNTERTYPE_SATIETY)
            If satiety.CurrentValue > satiety.UnitTypeCounter.MinimumValue Then
                satiety.CurrentValue -= 1
                AnsiConsole.MarkupLine($"{unit.UniqueName} loses 1 {satiety.CounterType.CounterTypeName}({satiety.CurrentValue}) due to {reason}.")
            Else
                ReduceUnitHealth(unit, reason)
            End If
        End If
    End Sub
End Module
