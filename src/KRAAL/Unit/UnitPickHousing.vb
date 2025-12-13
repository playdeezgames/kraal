Imports KRAAL.Domain

Friend Module UnitPickHousing
    Friend Sub Run(unit As IUnit)
        Dim choices As New List(Of Choice) From
            {
                New Choice("Never Mind", Sub() Return)
            }
        choices.AddRange(unit.Faction.AvailableHousing.Select(Function(x) New Choice(x.UniqueName, SetUnitHousing(unit, x))))
        Choice.Pick($"[olive]House {unit.UniqueName} where?[/]", choices)
    End Sub

    Friend Function SetUnitHousing(unit As IUnit, housing As IHousing) As Action
        Return Sub()
                   unit.Housing = housing
               End Sub
    End Function
End Module
