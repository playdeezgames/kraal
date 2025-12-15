Public Interface IUnitType
    ReadOnly Property UnitTypeId As Integer
    Property UnitTypeName As String
    ReadOnly Property UnitTypes As IUnitTypes
    Sub Remove()
    ReadOnly Property Counters As IUnitTypeCounters
End Interface
