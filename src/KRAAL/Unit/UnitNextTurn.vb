Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitNextTurn
    Friend Sub Run(unit As IUnit)
        Dim satiety = unit.Counters.FindByName(COUNTERTYPE_SATIETY)
        If satiety.CurrentValue > satiety.UnitTypeCounter.MinimumValue Then
            satiety.CurrentValue -= 1
            AnsiConsole.MarkupLine($"{unit.UniqueName} loses 1 {satiety.CounterType.CounterTypeName}({satiety.CurrentValue})")
        Else
            Dim health = unit.Counters.FindByName(COUNTERTYPE_HEALTH)
            If health.CurrentValue > health.UnitTypeCounter.MinimumValue Then
                health.CurrentValue -= 1
                AnsiConsole.MarkupLine($"{unit.UniqueName} loses 1 {health.CounterType.CounterTypeName}({health.CurrentValue})")
            End If
            If health.CurrentValue = health.UnitTypeCounter.MinimumValue Then
                AnsiConsole.MarkupLine($"{unit.UniqueName} is dead.")
                unit.Remove()
            End If
        End If
    End Sub
End Module
