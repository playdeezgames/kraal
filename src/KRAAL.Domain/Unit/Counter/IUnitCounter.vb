Public Interface IUnitCounter
    ReadOnly Property CounterType As ICounterType
    ReadOnly Property Unit As IUnit
    ReadOnly Property CurrentValue As Integer
End Interface
