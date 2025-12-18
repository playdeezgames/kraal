Imports KRAAL.Model
Imports TGGD.Presentation

Friend Module FactionEditListMenu
    Friend Sub Run(universe As IUniverseModel, ui As IUIContext)
        ui.RunMenu(
            (Mood.Prompt, "Edit Which Faction?"),
            Sub(addChoice, quit)
                addChoice("Never Mind", quit)
                For Each faction In universe.Factions
                    addChoice(faction.Name, ChooseFaction(faction, ui))
                Next
            End Sub)
    End Sub

    Private Function ChooseFaction(faction As IFactionModel, ui As IUIContext) As Action
        Return Sub()
                   FactionEditMenu.Run(faction, ui)
               End Sub
    End Function
End Module
