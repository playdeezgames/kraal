Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionAdmin
    Friend Sub Run(faction As IFaction, quitParent As Action)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Faction Id: {faction.FactionId}")
                                AnsiConsole.MarkupLine($"Faction Name: {faction.FactionName}")
                                choices.Add(New Choice("Rename Faction...", Sub() FactionRename.Run(faction)))
                                choices.Add(New Choice("Remove Faction", Sub()
                                                                             If Choice.Confirm("[red]Are you sure you want to remove this faction?[/]") Then
                                                                                 faction.Remove()
                                                                                 quit()
                                                                                 quitParent()
                                                                             End If
                                                                         End Sub))
                            End Sub)
    End Sub
End Module
