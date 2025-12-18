Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module FactionEditMenu
    Friend Sub Run(faction As IFactionModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Faction: {faction.Name}"))
                addChoice("Never Mind", quit)
            End Sub)
    End Sub
End Module
