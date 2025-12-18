Imports TGGD.Persistence

Friend Class Faction
    Implements IFaction

    Private ReadOnly store As IStore
    Private ReadOnly factionId As Integer

    Public Sub New(store As IStore, factionId As Integer)
        Me.store = store
        Me.factionId = factionId
    End Sub

    Public Property FactionName As String Implements IFaction.FactionName
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Private ReadOnly Property IFaction_FactionId As Integer Implements IFaction.FactionId
        Get
            Throw New NotImplementedException()
        End Get
    End Property
End Class
