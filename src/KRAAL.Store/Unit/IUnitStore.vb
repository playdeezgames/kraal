Public Interface IUnitStore
    Function Create(faction As IFaction, unitName As String) As IUnit
    Function CountForFaction(faction As IFaction) As Integer
    Function AllForFaction(faction As IFaction) As IEnumerable(Of IUnit)
    Sub Remove(unit As IUnit)
End Interface
