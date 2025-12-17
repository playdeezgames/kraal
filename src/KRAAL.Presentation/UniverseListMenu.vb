Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module UniverseListMenu
    Friend Sub Run(model As IKRAALModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Continue Which Universe?"),
            Sub(addChoice, quit)
                addChoice("Never Mind", quit)
                For Each universe In model.Universes
                    addChoice(universe.Name, ChooseUniverse(universe, ui, quit))
                Next
            End Sub)
    End Sub

    Private Function ChooseUniverse(universe As IUniverseModel, ui As IUIContext, quit As Action) As Action
        Return Sub()
                   UniverseMenu.Run(universe, ui, quit)
               End Sub
    End Function
End Module
