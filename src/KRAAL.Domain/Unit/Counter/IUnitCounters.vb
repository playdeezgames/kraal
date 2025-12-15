Public Interface IUnitCounters
    Function Create(counterType As ICounterType, initialValue As Integer) As IUnitCounter
End Interface
