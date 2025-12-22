Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module UniverseMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext, quitParent As Action)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                For Each ship In universe.PlayerParty.Ships
                    addChoice(ship.Name, ChooseShip(ship, ui))
                Next
                addChoice("Game Menu", ChooseGameMenu(universe, ui, Sub()
                                                                        quit()
                                                                        quitParent()
                                                                    End Sub))
            End Sub)
    End Sub

    Private Function ChooseShip(ship As IShipModel, ui As IUIContext) As Action
        Return Sub()
                   ShipMenu.Run(ship, ui)
               End Sub
    End Function

    Private Function ChooseGameMenu(universe As IUniverseModel, ui As IUIContext, quit As Action) As Action
        Return Sub()
                   GameMenu.Run(universe, ui, quit)
               End Sub
    End Function
End Module
