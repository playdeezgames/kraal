Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module StarEditListMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Edit Which Star?"),
            Sub(addChoice, quit)
                addChoice("Never Mind", quit)
                For Each star In universe.Stars
                    addChoice(star.Name, ChooseStar(star, ui))
                Next
            End Sub)
    End Sub

    Private Function ChooseStar(star As IStarModel, ui As IUIContext) As Action
        Return Sub()
                   StarEditMenu.Run(star, ui)
               End Sub
    End Function
End Module
