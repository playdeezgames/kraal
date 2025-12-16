Public Interface IUnitCounters
    Function Create(counterType As ICounterType, initialValue As Integer) As IUnitCounter
    ReadOnly Property Unit As IUnit
    ReadOnly Property All As IEnumerable(Of IUnitCounter)
    Function FindByName(name As String) As IUnitCounter
    ReadOnly Property UnitTypeCounter As IUnitTypeCounter
    Property CurrentValue As Integer
End Interface
