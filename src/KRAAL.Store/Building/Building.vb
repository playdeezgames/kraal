Friend Class Building
    Implements IBuilding
    Sub New(buildingId As Integer, buildingName As String)
        Me.BuildingId = buildingId
        Me.BuildingName = buildingName
    End Sub

    Public ReadOnly Property BuildingId As Integer Implements IBuilding.BuildingId

    Public ReadOnly Property BuildingName As String Implements IBuilding.BuildingName
End Class
