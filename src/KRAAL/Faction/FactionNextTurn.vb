Imports KRAAL.Domain

Friend Module FactionNextTurn
    Friend Sub Run(faction As IFaction)
        For Each unit In faction.AllUnits
            UnitNextTurn.Run(unit)
        Next
    End Sub
End Module
