Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module ShipNearbyStarListMenu

    Friend Sub Run(ship As IShipModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Stars Near {ship.Name}"))
                addChoice("Go Back", quit)
                For Each star In ship.NearbyStars.OrderBy(Function(x) x.Position.DistanceTo(ship.Position))
                    addChoice($"{star.Name}(Distance: {ship.Position.DistanceTo(star.Position):f2})", ChooseStar(ship, star, ui))
                Next
            End Sub)
    End Sub

    Private Function ChooseStar(ship As IShipModel, star As IStarModel, ui As IUIContext) As Action
        Return Sub()
                   NearbyStarMenu.Run(ship, star, ui)
               End Sub
    End Function
End Module
