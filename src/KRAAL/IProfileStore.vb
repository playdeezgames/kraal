Public Interface IProfileStore
    Function DoesNameExist(profileName As String) As Boolean
    Function Create(profileName As String) As IProfile
    ReadOnly Property All As IEnumerable(Of IProfile)
End Interface
