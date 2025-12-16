Public Interface IBuildingType
    ReadOnly Property BuildingTypeId As Integer
    Property BuildingTypeName As String
    Sub Remove()
    ReadOnly Property BuildingTypes As IBuildingTypes
End Interface
