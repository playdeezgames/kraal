Public Interface IProfiles
    ReadOnly Property All As IEnumerable(Of IProfile)
    ReadOnly Property BuildingTypes As IBuildingTypes
    ReadOnly Property CounterTypes As ICounterTypes
    ReadOnly Property UnitTypes As IUnitTypes
    Function DoesProfileNameExist(profileName As String) As Boolean
    Function CreateProfile(profileName As String) As IProfile
End Interface
