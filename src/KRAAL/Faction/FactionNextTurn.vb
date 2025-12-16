Imports KRAAL.Domain

Friend Module FactionNextTurn
    Friend Sub Run(faction As IFaction)
        For Each unit In faction.AllUnits
            UnitNextTurn.Run(unit)
        Next
        Choice.Pause("[olive]Onward...[/]")
    End Sub
End Module
