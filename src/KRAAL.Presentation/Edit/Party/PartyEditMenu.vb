Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module PartyEditMenu
    Friend Sub Run(
                  party As IPartyModel,
                  ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Now What?"),
            Sub(addChoice, quit)
                ui.Clear()
                ui.WriteLine((Mood.Info, $"Party ID: {party.ID}"))
                addChoice("Never Mind", quit)
                If party.IsPlayerParty Then
                    ui.WriteLine((Mood.Info, "PLAYER PARTY"))
                Else
                    addChoice("Set as Player Party", ChooseSetPlayerParty(party, ui))
                End If
            End Sub)
    End Sub

    Private Function ChooseSetPlayerParty(party As IPartyModel, ui As IUIContext) As Action
        Return Sub()
                   party.SetPlayerParty()
               End Sub
    End Function
End Module
