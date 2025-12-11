Friend Class UnitDTO
    Implements IUnitDTO
    Sub New(unitId As Integer, unitName As String)
        Me.UnitId = unitId
        Me.UnitName = unitName
    End Sub
    Public ReadOnly Property UnitId As Integer Implements IUnitDTO.UnitId
    Public ReadOnly Property UnitName As String Implements IUnitDTO.UnitName
End Class
