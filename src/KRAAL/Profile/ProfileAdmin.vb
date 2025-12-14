Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileAdmin
    Friend Sub Run(profile As IProfile, quitParent As Action)
        Menu.Run("Go Back", Sub(choices, quit)
                                AnsiConsole.MarkupLine($"Profile Id: {profile.ProfileId}")
                                AnsiConsole.MarkupLine($"Profile Name: {profile.ProfileName}")
                                choices.AddRange(
                                   {
                                       New Choice("Rename Profile...", Sub() ProfileRename.Run(profile)),
                                       New Choice("Remove Profile", Sub()
                                                                        If Choice.Confirm("[red]Are you sure you want to remove this profile?[/]") Then
                                                                            profile.Remove()
                                                                            quit()
                                                                            quitParent()
                                                                        End If
                                                                    End Sub)
                                   })
                            End Sub)
    End Sub
End Module
