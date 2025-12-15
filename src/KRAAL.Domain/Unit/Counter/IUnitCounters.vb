Public Interface IUnitCounters
    Function Create(counterType As ICounterType, initialValue As Integer) As IUnitCounter
    ReadOnly Property Unit As IUnit
    ReadOnly Property All As IEnumerable(Of IUnitCounter)
End Interface
