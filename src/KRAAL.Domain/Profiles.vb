Imports KRAAL.Store

Public Class Profiles
    Implements IProfiles

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore)
        Me.store = store
    End Sub
End Class
