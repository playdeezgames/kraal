Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module PartyEditMenu
    Friend Sub Run(
                  party As IPartyModel,
                  ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Party ID: {party.ID}"))
                addChoice("Never Mind", quit)
            End Sub)
    End Sub
End Module
