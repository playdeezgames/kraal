Imports KRAAL.Domain

Friend Module HousingPickUnit
    Friend Sub Run(housing As IHousing)
        Dim choices As New List(Of Choice) From
            {
                New Choice("Never Mind", Sub() Return)
            }
        choices.AddRange(housing.Building.Faction.UnhousedUnits.Select(Function(x) New Choice(x.UniqueName, SetUnitHousing(x, housing))))
        Choice.Pick($"[olive]Assign whom to {housing.UniqueName}?[/]", choices)
    End Sub
End Module
