Public Interface ICounterTypes
    Function DoesNameExist(name As String) As Boolean
    Function Create(name As String) As ICounterType
    ReadOnly Property All As IEnumerable(Of ICounterType)
End Interface
