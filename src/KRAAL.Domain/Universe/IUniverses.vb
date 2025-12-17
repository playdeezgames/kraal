Public Interface IUniverses
    ReadOnly Property Count As Integer
    Function FindByName(universeName As String) As Boolean
    Function Create(universeName As String) As IUniverse
    ReadOnly Property All As IEnumerable(Of IUniverse)
End Interface
