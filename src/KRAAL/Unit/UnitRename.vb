Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitRename
    Friend Sub Run(unit As IUnit)
        Dim oldName = unit.UnitName
        unit.UnitName = AnsiConsole.Ask($"[olive]New name for unit:[/]", oldName)
    End Sub

End Module
