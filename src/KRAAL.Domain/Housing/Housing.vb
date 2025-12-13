Imports KRAAL.Store

Friend Class Housing
    Implements IHousing
    Private ReadOnly store As IDataStore
    Sub New(store As IDataStore, housingId As Integer)
        Me.store = store
        Me.HousingId = housingId
    End Sub

    Public ReadOnly Property HousingId As Integer Implements IHousing.HousingId

    Public ReadOnly Property Building As IBuilding Implements IHousing.Building
        Get
            Return New Building(store, CInt(store.GetColumnValue(TABLE_HOUSINGS, COLUMN_BUILDING_ID, (COLUMN_HOUSING_ID, HousingId))))
        End Get
    End Property
End Class
