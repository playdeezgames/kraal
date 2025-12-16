Public Interface IUnit
    ReadOnly Property UniqueName As String
    Property UnitName As String
    ReadOnly Property UnitId As Integer
    ReadOnly Property Faction As IFaction
    Property Housing As IHousing
    ReadOnly Property UnitType As IUnitType
    ReadOnly Property Counters As IUnitCounters
    Sub Remove()
End Interface
