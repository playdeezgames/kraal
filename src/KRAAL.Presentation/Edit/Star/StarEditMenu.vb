Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module StarEditMenu
    Friend Sub Run(star As IStarModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Star: {star.Name}"))
                Dim position = star.Position
                ui.WriteLine((Mood.Info, $"Position: ({position.X:f2}, {position.Y:f2}, {position.Z:f2})"))
                addChoice("Never Mind", quit)
            End Sub)
    End Sub
End Module
