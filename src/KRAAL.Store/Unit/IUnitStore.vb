Public Interface IUnitStore
    Function Create(faction As IFaction, unitName As String, housing As IHousing) As IUnit
    Function CountForFaction(faction As IFaction) As Integer
    Function AllForFaction(faction As IFaction) As IEnumerable(Of IUnit)
    Sub Remove(unit As IUnit)
    Function GetDetail(unit As IUnit) As IUnitDetail
End Interface
