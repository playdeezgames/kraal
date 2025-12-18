Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module UniverseMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext, quitParent As Action)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                addChoice("Game Menu", ChooseGameMenu(universe, ui, Sub()
                                                                        quit()
                                                                        quitParent()
                                                                    End Sub))
            End Sub)
    End Sub

    Private Function ChooseGameMenu(universe As IUniverseModel, ui As IUIContext, quit As Action) As Action
        Return Sub()
                   GameMenu.Run(universe, ui, quit)
               End Sub
    End Function
End Module
