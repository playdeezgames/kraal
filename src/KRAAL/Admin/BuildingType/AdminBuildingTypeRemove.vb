Imports KRAAL.Domain

Friend Module AdminBuildingTypeRemove
    Friend Sub Run(buildingType As IBuildingType, quitParent As Action)
        If Choice.Confirm($"[red]Are you sure you want to remove building type {buildingType.BuildingTypeName}?[/]") Then
            buildingType.Remove()
            quitParent()
        End If
    End Sub
End Module
