Imports KRAAL.Domain
Imports Spectre.Console

Friend Module ProfileRename
    Friend Sub Run(profile As IProfile)
        Dim oldName As String = profile.ProfileName
        Dim newName = AnsiConsole.Ask(Of String)($"[olive]New Profile Name:[/]", oldName)
        If profile.Profiles.DoesProfileNameExist(newName) Then
            Choice.Pause($"[red]There is already a profile named {newName}![/]")
            Return
        End If
        profile.ProfileName = newName
    End Sub
End Module
