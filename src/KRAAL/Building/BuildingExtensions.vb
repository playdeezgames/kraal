Imports System.Runtime.CompilerServices
Imports KRAAL.Store

Friend Module BuildingExtensions
    <Extension>
    Friend Function UniqueName(building As IBuilding) As String
        Return $"{building.BuildingName}(#{building.BuildingId})"
    End Function
End Module
