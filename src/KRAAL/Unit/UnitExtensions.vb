Imports System.Runtime.CompilerServices
Imports KRAAL.Store

Friend Module UnitExtensions
    <Extension>
    Friend Function UniqueName(unit As IUnitDTO) As String
        Return $"{unit.UnitName}(#{unit.UnitId})"
    End Function
End Module
