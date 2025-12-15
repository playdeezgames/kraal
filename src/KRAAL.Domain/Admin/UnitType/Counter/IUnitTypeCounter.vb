Public Interface IUnitTypeCounter
    ReadOnly Property CounterType As ICounterType
    ReadOnly Property UnitType As IUnitType
    Property InitialValue As Integer
    Property MinimumValue As Integer
    Property MaximumValue As Integer
    Sub Remove()
End Interface
