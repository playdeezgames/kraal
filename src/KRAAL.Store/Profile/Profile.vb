Friend Class Profile
    Implements IProfile
    Friend Sub New(profileId As Integer, profileName As String)
        Me.ProfileId = profileId
        Me.ProfileName = profileName
    End Sub
    Public ReadOnly Property ProfileId As Integer Implements IProfile.ProfileId
    Public ReadOnly Property ProfileName As String Implements IProfile.ProfileName
End Class
