Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitTypeRename
    Friend Sub Run(unitType As IUnitType)
        Dim name = AnsiConsole.Ask("[olive]New Name:[/]", unitType.UnitTypeName)
        If unitType.unitTypes.DoesNameExist(name) Then
            Choice.Pause("[red]That name already exists![/]")
            Return
        End If
        unitType.UnitTypeName = name
    End Sub
End Module
