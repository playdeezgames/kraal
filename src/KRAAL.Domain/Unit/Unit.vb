Imports KRAAL.Store

Friend Class Unit
    Implements IUnit

    Private ReadOnly store As IDataStore

    Public Sub New(store As IDataStore, unitId As Integer)
        Me.store = store
        Me.UnitId = unitId
    End Sub

    Public ReadOnly Property UniqueName As String Implements IUnit.UniqueName
        Get
            Return $"{UnitName}(#{UnitId})"
        End Get
    End Property

    Public Property UnitName As String Implements IUnit.UnitName
        Get
            Return CStr(store.GetColumnValue(
                TABLE_UNITS,
                COLUMN_UNIT_NAME,
                (COLUMN_UNIT_ID, UnitId)))
        End Get
        Set(value As String)
            store.PutColumnValue(
                TABLE_UNITS,
                (COLUMN_UNIT_NAME, value),
                (COLUMN_UNIT_ID, UnitId))
        End Set
    End Property

    Public ReadOnly Property UnitId As Integer Implements IUnit.UnitId

    Public ReadOnly Property Faction As IFaction Implements IUnit.Faction
        Get
            Return New Faction(
                store,
                CInt(store.GetColumnValue(TABLE_UNITS, COLUMN_FACTION_ID, (COLUMN_UNIT_ID, UnitId))))
        End Get
    End Property

    Public Property Housing As IHousing Implements IUnit.Housing
        Get
            Dim housingId = store.GetColumnValue(TABLE_UNITS, COLUMN_HOUSING_ID, (COLUMN_UNIT_ID, UnitId))
            If housingId Is Nothing Then
                Return Nothing
            End If
            Return New Housing(store, CInt(housingId))
        End Get
        Set(value As IHousing)
            store.PutColumnValue(TABLE_UNITS, (COLUMN_HOUSING_ID, value?.HousingId), (COLUMN_UNIT_ID, UnitId))
        End Set
    End Property

    Public ReadOnly Property UnitType As IUnitType Implements IUnit.UnitType
        Get
            Return New UnitType(
                store,
                CInt(store.GetColumnValue(TABLE_UNITS, COLUMN_UNIT_TYPE_ID, (COLUMN_UNIT_ID, UnitId))))
        End Get
    End Property

    Public ReadOnly Property Counters As IUnitCounters Implements IUnit.Counters
        Get
            Return New UnitCounters(store, UnitId)
        End Get
    End Property
End Class
