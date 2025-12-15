Public Interface IUnitTypeCounters
    ReadOnly Property All As IEnumerable(Of IUnitTypeCounter)
    ReadOnly Property UnitType As IUnitType
    ReadOnly Property AvailableCounterTypes As IEnumerable(Of ICounterType)
    Function Create(counterType As ICounterType, initial As Integer, minimum As Integer, maximum As Integer) As IUnitTypeCounter
End Interface
