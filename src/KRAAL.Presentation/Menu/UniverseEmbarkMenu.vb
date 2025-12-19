Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module UniverseEmbarkMenu
    Private Const CHOICE_PLAY = "Play!"
    Private Const CHOICE_EDIT = "Edit"
    Friend Sub Run(model As IKRAALModel, ui As IUIContext, quitParent As Action)
        Dim universeName = ui.Ask(Of String)((Mood.Prompt, "Universe Name:"), String.Empty)
        If model.HasUniverseWithName(universeName) Then
            ui.Message((Mood.Danger, $"There is already a universe named '{universeName}'."))
            Return
        End If
        Dim universe = model.CreateUniverse(universeName)
        Select Case ui.Choose((Mood.Prompt, "Now What?"), CHOICE_PLAY, CHOICE_EDIT)
            Case CHOICE_PLAY
                UniverseMenu.Run(universe, ui, Sub() Return)
            Case Else
                UniverseEditMenu.Run(universe, ui, Sub() Return)
        End Select
    End Sub
End Module
