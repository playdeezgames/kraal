Public Interface IProfiles
    ReadOnly Property All As IEnumerable(Of IProfile)
    Function DoesProfileNameExist(profileName As String) As Boolean
    Function CreateProfile(profileName As String) As IProfile
End Interface
