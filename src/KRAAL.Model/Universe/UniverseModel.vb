Imports KRAAL.Domain

Friend Class UniverseModel
    Implements IUniverseModel

    Private ReadOnly universe As IUniverse

    Friend Sub New(universe As IUniverse)
        Me.universe = universe
    End Sub

    Public ReadOnly Property Name As String Implements IUniverseModel.Name
        Get
            Return universe.UniverseName
        End Get
    End Property

    Public ReadOnly Property Factions As IEnumerable(Of IFactionModel) Implements IUniverseModel.Factions
        Get
            Return universe.Factions.All.Select(Function(x) New FactionModel(x))
        End Get
    End Property

    Public ReadOnly Property Stars As IEnumerable(Of IStarModel) Implements IUniverseModel.Stars
        Get
            Return universe.Stars.All.Select(Function(x) New StarModel(x))
        End Get
    End Property

    Public ReadOnly Property Parties As IEnumerable(Of IPartyModel) Implements IUniverseModel.Parties
        Get
            Return universe.Parties.All.Select(Function(x) New PartyModel(x))
        End Get
    End Property

    Public ReadOnly Property PlayerParty As IPartyModel Implements IUniverseModel.PlayerParty
        Get
            Dim party = universe.PlayerParty
            Return If(party IsNot Nothing, New PartyModel(party), Nothing)
        End Get
    End Property

    Public Sub Remove() Implements IUniverseModel.Remove
        universe.Remove()
    End Sub

    Public Function TrySetName(newName As String) As Boolean Implements IUniverseModel.TrySetName
        If universe.Universes.FindByName(newName) Then
            Return False
        End If
        universe.UniverseName = newName
        Return True
    End Function

    Public Function HasPlayerParty() As Boolean Implements IUniverseModel.HasPlayerParty
        Return universe.PlayerParty IsNot Nothing
    End Function

    Public Function CreateParty() As IPartyModel Implements IUniverseModel.CreateParty
        Return New PartyModel(universe.Parties.Create())
    End Function
End Class
