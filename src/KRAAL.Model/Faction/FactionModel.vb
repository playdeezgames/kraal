Imports KRAAL.Domain

Friend Class FactionModel
    Implements IFactionModel

    Private ReadOnly faction As IFaction

    Public Sub New(faction As IFaction)
        Me.faction = faction
    End Sub

    Public ReadOnly Property Name As String Implements IFactionModel.Name
        Get
            Return faction.FactionName
        End Get
    End Property
End Class
