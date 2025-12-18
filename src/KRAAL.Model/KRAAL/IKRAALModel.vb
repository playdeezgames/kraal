Public Interface IKRAALModel
    ReadOnly Property HasUniverses As Boolean
    Function HasUniverseWithName(universeName As String) As Boolean
    Function CreateUniverse(universeName As String) As IUniverseModel
    ReadOnly Property Universes As IEnumerable(Of IUniverseModel)
End Interface
