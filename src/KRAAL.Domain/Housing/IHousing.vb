Public Interface IHousing
    ReadOnly Property HousingId As Integer
    ReadOnly Property UniqueName As String
    ReadOnly Property Building As IBuilding
    ReadOnly Property Unit As IUnit
End Interface
