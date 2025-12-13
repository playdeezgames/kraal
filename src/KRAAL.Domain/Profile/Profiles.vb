Imports KRAAL.Store

Public Class Profiles
    Implements IProfiles

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub

    Public ReadOnly Property All As IEnumerable(Of IProfile) Implements IProfiles.All
        Get
            Return store.GetList(Of IProfile)(
                TABLE_PROFILES,
                {
                    COLUMN_PROFILE_ID
                },
                {},
                COLUMN_PROFILE_NAME,
                Function(x) New Profile(store, x.GetInt32(0)))
        End Get
    End Property

    Public Function DoesProfileNameExist(profileName As String) As Boolean Implements IProfiles.DoesProfileNameExist
        Return store.GetCount(TABLE_PROFILES, {(COLUMN_PROFILE_NAME, profileName)}) > 0
    End Function

    Public Function CreateProfile(profileName As String) As IProfile Implements IProfiles.CreateProfile
        Return New Profile(store, CInt(store.Create(TABLE_PROFILES, {(COLUMN_PROFILE_NAME, profileName)}, COLUMN_PROFILE_ID)))
    End Function
End Class
