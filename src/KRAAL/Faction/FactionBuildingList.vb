Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionBuildingList
    Friend Sub Run(faction As IFaction)
        Menu.Run(Sub(choices, quit)
                     AnsiConsole.MarkupLine($"Buildings for faction `{faction.FactionName}`")
                     For Each building In faction.AllBuildings
                         choices.Add(New Choice(building.UniqueName(), Sub() BuildingDetail.Run(building)))
                     Next
                 End Sub)
    End Sub
End Module
