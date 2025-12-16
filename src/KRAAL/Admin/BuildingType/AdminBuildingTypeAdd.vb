Imports KRAAL.Domain
Imports Spectre.Console

Friend Module AdminBuildingTypeAdd
    Friend Sub Run(buildingTypes As IBuildingTypes)
        Dim name = AnsiConsole.Ask("[olive]New Building Type Name:[/]", String.Empty)
        If String.IsNullOrWhiteSpace(name) Then
            Return
        End If
        If buildingTypes.DoesNameExist(name) Then
            Choice.Pause("[red]That Building Type name already exists![/]")
            Return
        End If
        AdminBuildingTypeDetail.Run(buildingTypes.Create(name))
    End Sub
End Module
