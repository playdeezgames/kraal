Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminBuildingTypeRename
    Friend Sub Run(buildingType As IBuildingType)
        Dim name = AnsiConsole.Ask("[olive]New Name:[/]", buildingType.BuildingTypeName)
        If buildingType.buildingTypes.DoesNameExist(name) Then
            Choice.Pause("[red]That name already exists![/]")
            Return
        End If
        buildingType.BuildingTypeName = name
    End Sub
End Module
