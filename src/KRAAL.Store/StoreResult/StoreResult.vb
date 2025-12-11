Imports MySqlConnector

Friend Class StoreResult
    Implements IStoreResult

    Private ReadOnly reader As MySqlDataReader

    Public Sub New(reader As MySqlDataReader)
        Me.reader = reader
    End Sub

    Public Function GetInt32(index As Integer) As Integer Implements IStoreResult.GetInt32
        Return reader.GetInt32(index)
    End Function

    Public Function GetString(index As Integer) As String Implements IStoreResult.GetString
        Return reader.GetString(index)
    End Function

    Public Function IsDBNull(index As Integer) As Boolean Implements IStoreResult.IsDBNull
        Return reader.IsDBNull(index)
    End Function
End Class
