Public Interface IUniverseModel
    ReadOnly Property Name As String
    Sub Remove()
    Function TrySetName(newName As String) As Boolean
End Interface
