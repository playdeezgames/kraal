Imports KRAAL.Domain

Friend Module UnitTypeRemove
    Friend Sub Run(unitType As IUnitType, quitParent As Action)
        If Choice.Confirm($"[red]Are you sure you want to remove unit type {unitType.UnitTypeName}?[/]") Then
            unitType.Remove()
            quitParent()
        End If
    End Sub
End Module
