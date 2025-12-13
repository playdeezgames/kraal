Public Interface IBuilding
    Function CreateHousing() As IHousing
    Function UniqueName() As String
    ReadOnly Property BuildingId As Integer
    Property BuildingName As String
End Interface
