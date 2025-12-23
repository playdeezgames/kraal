Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module NearbyStarMenu
    Friend Sub Run(ship As IShipModel, star As IStarModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Nearby Star: {star.Name}"))
                addChoice("Never Mind", quit)
            End Sub)
    End Sub
End Module
