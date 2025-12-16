Public Interface IBuildingTypes
    ReadOnly Property All As IEnumerable(Of IBuildingType)
    Function DoesNameExist(buildingTypeName As String) As Boolean
    Function Create(buildingTypeName As String) As IBuildingType
    Function FindByName(buildingTypeName As String) As IBuildingType
End Interface
