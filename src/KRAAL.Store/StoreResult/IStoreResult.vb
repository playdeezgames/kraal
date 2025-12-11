Public Interface IStoreResult
    Function GetInt32(index As Integer) As Integer
    Function GetString(index As Integer) As String
    Function IsDBNull(index As Integer) As Boolean
End Interface
