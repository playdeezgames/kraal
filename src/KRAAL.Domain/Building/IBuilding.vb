Public Interface IBuilding
    Function CreateHousing() As IHousing
    Function UniqueName() As String
    ReadOnly Property BuildingId As Integer
    Property BuildingName As String
    ReadOnly Property HousingCount As Integer
    ReadOnly Property Housings As IEnumerable(Of IHousing)
    ReadOnly Property Faction As IFaction
End Interface
