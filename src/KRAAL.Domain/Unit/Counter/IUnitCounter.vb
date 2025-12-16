Public Interface IUnitCounter
    ReadOnly Property CounterType As ICounterType
    ReadOnly Property Unit As IUnit
    ReadOnly Property UnitTypeCounter As IUnitTypeCounter
    Property CurrentValue As Integer
End Interface
