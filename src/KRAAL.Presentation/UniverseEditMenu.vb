Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module UniverseEditMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext, quitParent As Action)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                addChoice("Exit", Sub()
                                      quit()
                                      quitParent()
                                  End Sub)
            End Sub)
    End Sub
End Module
