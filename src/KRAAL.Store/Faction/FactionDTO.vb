Friend Class FactionDTO
    Implements IFactionDTO
    Friend Sub New(factionId As Integer, factionName As String)
        Me.FactionId = factionId
        Me.FactionName = factionName
    End Sub

    Public ReadOnly Property FactionId As Integer Implements IFactionDTO.FactionId

    Public ReadOnly Property FactionName As String Implements IFactionDTO.FactionName
End Class
