Imports KRAAL.Domain
Imports Spectre.Console

Friend Module BuildingRename
    Friend Sub Run(building As IBuilding)
        Dim oldName = building.BuildingName
        building.BuildingName = AnsiConsole.Ask($"[olive]New name for building:[/]", oldName)
    End Sub
End Module
