Public Interface IUniverseModel
    ReadOnly Property Name As String
    Sub Remove()
    Function TrySetName(newName As String) As Boolean
    ReadOnly Property Factions As IEnumerable(Of IFactionModel)
    ReadOnly Property Stars As IEnumerable(Of IStarModel)
    ReadOnly Property Parties As IEnumerable(Of IPartyModel)
End Interface
