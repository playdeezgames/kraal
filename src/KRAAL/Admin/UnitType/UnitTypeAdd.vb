Imports KRAAL.Domain
Imports Spectre.Console

Friend Module UnitTypeAdd
    Friend Sub Run(unitTypes As IUnitTypes)
        Dim name = AnsiConsole.Ask("[olive]New Unit Type Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(name) Then
            Return
        End If
        If unitTypes.DoesNameExist(name) Then
            Choice.Pause("[red]That Unit Type name already exists![/]")
            Return
        End If
        UnitTypeDetail.Run(unitTypes.Create(name))
    End Sub
End Module
