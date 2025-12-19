Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module PartyEditListMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Edit Which Party?"),
            Sub(addChoice, quit)
                addChoice("Never Mind", quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Universe: {universe.Name}"))
                If universe.HasPlayerParty Then
                    ui.WriteLine((Mood.Info, $"Player Party: {universe.PlayerParty.ID}"))
                Else
                    ui.WriteLine((Mood.Info, $"Player Party: None"))
                End If
                For Each party In universe.Parties
                    addChoice(party.ID, ChooseParty(party, ui))
                Next
            End Sub)
    End Sub

    Private Function ChooseParty(party As IPartyModel, ui As IUIContext) As Action
        Return Sub()
                   PartyEditMenu.Run(party, ui)
               End Sub
    End Function
End Module
