Imports KRAAL.Domain

Friend Class UniverseModel
    Implements IUniverseModel

    Private ReadOnly universe As IUniverse

    Friend Sub New(universe As IUniverse)
        Me.universe = universe
    End Sub

    Public ReadOnly Property Name As String Implements IUniverseModel.Name
        Get
            Return universe.UniverseName
        End Get
    End Property

    Public Sub Remove() Implements IUniverseModel.Remove
        universe.Remove()
    End Sub

    Public Function TrySetName(newName As String) As Boolean Implements IUniverseModel.TrySetName
        If universe.Universes.FindByName(newName) Then
            Return False
        End If
        universe.UniverseName = newName
        Return True
    End Function
End Class
