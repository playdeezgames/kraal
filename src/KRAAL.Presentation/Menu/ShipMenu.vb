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
                addChoice("Quit", quit)
            End Sub)
    End Sub
End Module
