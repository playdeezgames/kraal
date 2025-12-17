Imports System.Security.Cryptography.X509Certificates
Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module GameMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext, quitParent As Action)
        ui.RunMenu(
            (Mood.Prompt, "Game Menu:"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Universe Name: {universe.Name}"))
                addChoice("Continue", quit)
                addChoice("Rename...", ChooseRename(universe, ui))
                addChoice("Exit to Main Menu", ChooseExit(ui, Sub()
                                                                  quit()
                                                                  quitParent()
                                                              End Sub))
            End Sub)
    End Sub

    Private Function ChooseRename(universe As IUniverseModel, ui As IUIContext) As Action
        Return Sub()
                   If universe.TrySetName(ui.Ask(Of String)((Mood.Prompt, "New Name:"), universe.Name)) Then
                       ui.Message((Mood.Success, "Success!"))
                   Else
                       ui.Message((Mood.Failure, "Failure!"))
                   End If
               End Sub
    End Function

    Private Function ChooseExit(ui As IUIContext, quit As Action) As Action
        Return Sub()
                   If ui.Confirm((Mood.Danger, "Are you sure you want to exit?")) Then
                       quit()
                   End If
               End Sub
    End Function
End Module
