Friend Class BuildingDTO
    Implements IBuildingDTO
    Sub New(buildingId As Integer, buildingName As String)
        Me.BuildingId = buildingId
        Me.BuildingName = buildingName
    End Sub

    Public ReadOnly Property BuildingId As Integer Implements IBuildingDTO.BuildingId

    Public ReadOnly Property BuildingName As String Implements IBuildingDTO.BuildingName
End Class
