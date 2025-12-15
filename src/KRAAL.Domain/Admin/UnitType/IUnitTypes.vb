Public Interface IUnitTypes
    Function DoesNameExist(name As String) As Boolean
    Function Create(name As String) As IUnitType
    ReadOnly Property All As IEnumerable(Of IUnitType)
    Function FindByName(unitTypeName As String) As IUnitType
End Interface
