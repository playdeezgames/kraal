Imports KRAAL.Domain
Imports Spectre.Console

Friend Module FactionRename
    Friend Sub Run(faction As IFaction)
        Dim oldName As String = faction.FactionName
        Dim newName = AnsiConsole.Ask(Of String)($"[olive]New Faction Name:[/]", oldName)
        If faction.Profile.DoesFactionNameExist(newName) Then
            Choice.Pause($"[red]There is already a faction named {newName}![/]")
            Return
        End If
        faction.FactionName = newName
    End Sub
End Module
