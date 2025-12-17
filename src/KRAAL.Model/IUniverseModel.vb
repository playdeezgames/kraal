Public Interface IUniverseModel
    ReadOnly Property Name As String
    Function TrySetName(newName As String) As Boolean
End Interface
