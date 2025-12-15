Public Interface IUnitTypeCounter
    ReadOnly Property CounterType As ICounterType
    ReadOnly Property UnitType As IUnitType
    ReadOnly Property InitialValue As Integer
    ReadOnly Property MinimumValue As Integer
    ReadOnly Property MaximumValue As Integer
End Interface
