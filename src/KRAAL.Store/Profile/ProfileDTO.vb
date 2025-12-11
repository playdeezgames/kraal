Friend Class ProfileDTO
    Implements IProfileDTO
    Friend Sub New(profileId As Integer, profileName As String)
        Me.ProfileId = profileId
        Me.ProfileName = profileName
    End Sub
    Public ReadOnly Property ProfileId As Integer Implements IProfileDTO.ProfileId
    Public ReadOnly Property ProfileName As String Implements IProfileDTO.ProfileName
End Class
