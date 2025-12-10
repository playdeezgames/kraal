Friend Class Faction
    Implements IFaction
    Friend Sub New(factionId As Integer, factionName As String)
        Me.FactionId = factionId
        Me.FactionName = factionName
    End Sub

    Public ReadOnly Property FactionId As Integer Implements IFaction.FactionId

    Public ReadOnly Property FactionName As String Implements IFaction.FactionName
End Class
