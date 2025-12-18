Public Interface IKRAALModel
    ReadOnly Property HasUniverses As Boolean
    Function HasUniverseWithName(universeName As String) As Boolean
    Function CreateUniverse(universeName As String) As IUniverseModel
    ReadOnly Property Universes As IEnumerable(Of IUniverseModel)
    Sub Export(filename As String)
    Sub Import(filename As String)
End Interface
