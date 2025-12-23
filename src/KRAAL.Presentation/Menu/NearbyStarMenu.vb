Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module NearbyStarMenu
    Friend Sub Run(ship As IShipModel, star As IStarModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Nearby Star: {star.Name}"))
                ui.WriteLine((Mood.Info, $"Distance: {star.Position.DistanceTo(ship.Position):f2}"))
                Dim heading = ship.Position.HeadingTo(star.Position)
                ui.WriteLine((Mood.Info, $"Heading: {heading.Theta:f2} mark {heading.Phi:f2}"))
                addChoice("Never Mind", quit)
            End Sub)
    End Sub
End Module
