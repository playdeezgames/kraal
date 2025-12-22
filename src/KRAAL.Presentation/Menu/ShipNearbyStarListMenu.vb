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
                For Each star In ship.NearbyStars
                    addChoice(star.Name, ChooseStar(ship, star, ui))
                Next
            End Sub)
    End Sub

    Private Function ChooseStar(ship As IShipModel, star As IStarModel, ui As IUIContext) As Action
        Return Sub()
                   Throw New NotImplementedException()
               End Sub
    End Function
End Module
