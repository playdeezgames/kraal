
Imports Microsoft.Data.Sqlite

Friend Class Record
    Implements IRecord

    Private ReadOnly reader As SqliteDataReader

    Public Sub New(reader As SqliteDataReader)
        Me.reader = reader
    End Sub

    Public Function GetInt32(index As Integer) As Integer Implements IRecord.GetInt32
        Return reader.GetInt32(index)
    End Function
End Class
