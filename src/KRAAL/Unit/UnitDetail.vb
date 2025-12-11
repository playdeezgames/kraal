Imports KRAAL.Store
Imports Spectre.Console

Friend Module UnitDetail
    Friend Sub Run(dataStore As IDataStore, unit As IUnitDTO)
        Dim running = True
        Do While running
            AnsiConsole.Clear()
            Dim details = dataStore.Units.GetDetail(unit)
            AnsiConsole.MarkupLine($"Unit: {details.UnitName}")
            If details.HousingId.HasValue Then
                AnsiConsole.MarkupLine($"Building: {details.HousingBuildingName}")
            Else
                AnsiConsole.MarkupLine($"Building: None")
            End If
            AnsiConsole.MarkupLine($"Faction: {details.FactionName}")
            Dim choices As New List(Of Choice) From
                {
                    New Choice("Go Back", Sub() running = False)
                }
            If details.HousingId.HasValue Then
                choices.Add(New Choice("Unhouse", Sub() dataStore.Units.SetHousing(unit, Nothing)))
            End If
            Choice.Pick("[olive]Now What?[/]", choices)
        Loop
    End Sub
End Module
