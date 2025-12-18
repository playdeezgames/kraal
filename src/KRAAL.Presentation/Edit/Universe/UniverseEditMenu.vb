Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module UniverseEditMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext, quitParent As Action)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                addChoice("Factions...", ChooseFactions(universe, ui))
                addChoice("Stars...", ChooseStars(universe, ui))
                addChoice("Exit", Sub()
                                      quit()
                                      quitParent()
                                  End Sub)
            End Sub)
    End Sub

    Private Function ChooseStars(universe As IUniverseModel, ui As IUIContext) As Action
        Return Sub()
                   StarEditListMenu.Run(universe, ui)
               End Sub
    End Function

    Private Function ChooseFactions(universe As IUniverseModel, ui As IUIContext) As Action
        Return Sub()
                   FactionEditListMenu.Run(universe, ui)
               End Sub
    End Function
End Module
