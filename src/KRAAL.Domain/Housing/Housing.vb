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

    Public ReadOnly Property UniqueName As String Implements IHousing.UniqueName
        Get
            Return $"{Building.BuildingName}(#{Building.BuildingId}-{HousingId})"
        End Get
    End Property

    Public ReadOnly Property Unit As IUnit Implements IHousing.Unit
        Get
            Dim unitId = store.GetColumnValue(TABLE_UNITS, COLUMN_UNIT_ID, (COLUMN_HOUSING_ID, HousingId))
            If unitId Is Nothing Then
                Return Nothing
            End If
            Return New Unit(store, CInt(unitId))
        End Get
    End Property
End Class
