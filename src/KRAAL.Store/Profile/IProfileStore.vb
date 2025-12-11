Public Interface IProfileStore
    Function DoesNameExist(profileName As String) As Boolean
    Function Create(profileName As String) As IProfileDTO
    Sub Remove(profile As IProfileDTO)
    ReadOnly Property All As IEnumerable(Of IProfileDTO)
End Interface
