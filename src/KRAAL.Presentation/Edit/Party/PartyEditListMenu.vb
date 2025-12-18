Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module PartyEditListMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Edit Which Party?"),
            Sub(addChoice, quit)
                addChoice("Never Mind", quit)
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
