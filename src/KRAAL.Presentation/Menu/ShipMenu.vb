Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module ShipMenu
    Friend Sub Run(ship As IShipModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Ship: {ship.Name}"))
                addChoice("Quit", quit)
            End Sub)
    End Sub
End Module
