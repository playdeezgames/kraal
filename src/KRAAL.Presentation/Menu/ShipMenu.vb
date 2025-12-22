Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module ShipMenu
    Friend Sub Run(ship As IShipModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Ship: {ship.Name}"))
                Dim position = ship.Position
                ui.WriteLine((Mood.Info, $"Position: ({position.X:f2}, {position.Y:f2}, {position.Z:f2})"))
                addChoice("Go Back", quit)
                addChoice("Nearby Stars...", ChooseNearbyStars(ship, ui))
            End Sub)
    End Sub

    Private Function ChooseNearbyStars(ship As IShipModel, ui As IUIContext) As Action
        Return Sub()
                   ShipNearbyStarListMenu.Run(ship, ui)
               End Sub
    End Function
End Module
