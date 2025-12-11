Friend Class Unit
    Implements IUnit
    Sub New(unitId As Integer, unitName As String)
        Me.UnitId = unitId
        Me.UnitName = unitName
    End Sub
    Public ReadOnly Property UnitId As Integer Implements IUnit.UnitId
    Public ReadOnly Property UnitName As String Implements IUnit.UnitName
End Class
