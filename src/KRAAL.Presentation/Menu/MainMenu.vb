Imports KRAAL.Model
Imports TGGD.Presentation

Public Module MainMenu
    Public Sub Run(model As IKRAALModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Main Menu:"),
            Sub(addChoice, quit)
                ui.Clear()
                If model.HasUniverses Then
                    addChoice("Continue...", ChooseContinue(model, ui))
                    addChoice("Edit...", ChooseEdit(model, ui))
                End If
                addChoice("New...", ChooseNew(model, ui))
                addChoice("Quit", ChooseQuit(model, ui, quit))
            End Sub)
    End Sub

    Private Function ChooseEdit(model As IKRAALModel, ui As IUIContext) As Action
        Return Sub()
                   UniverseEditListMenu.Run(model, ui)
               End Sub
    End Function

    Private Function ChooseNew(model As IKRAALModel, ui As IUIContext) As Action
        Return Sub()
                   Dim universeName = ui.Ask(Of String)((Mood.Prompt, "Universe Name:"), String.Empty)
                   If model.HasUniverseWithName(universeName) Then
                       ui.Message((Mood.Danger, $"There is already a universe named '{universeName}'."))
                       Return
                   End If
                   Dim universe = model.CreateUniverse(universeName)
                   UniverseMenu.Run(universe, ui, Sub() Return)
               End Sub
    End Function

    Private Function ChooseContinue(model As IKRAALModel, ui As IUIContext) As Action
        Return Sub()
                   UniverseListMenu.Run(model, ui)
               End Sub
    End Function

    Private Function ChooseQuit(model As IKRAALModel, ui As IUIContext, quit As Action) As Action
        Return Sub()
                   If ui.Confirm((Mood.Danger, "Are you sure you want to quit?")) Then
                       quit()
                   End If
               End Sub
    End Function
End Module
