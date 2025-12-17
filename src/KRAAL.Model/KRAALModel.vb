Imports KRAAL.Domain
Imports TGGD.Persistence

Public Class KRAALModel
    Implements IKRAALModel
    Private ReadOnly universes As IUniverses
    Private Sub New(store As IStore)
        Me.universes = Domain.Universes.Create(store)
    End Sub
    Public ReadOnly Property HasUniverses As Boolean Implements IKRAALModel.HasUniverses
        Get
            Return universes.Count > 0
        End Get
    End Property

    Private ReadOnly Property IKRAALModel_Universes As IEnumerable(Of IUniverseModel) Implements IKRAALModel.Universes
        Get
            Return universes.All.Select(Function(x) New UniverseModel(x))
        End Get
    End Property

    Public Shared Function Create(store As IStore) As IKRAALModel
        Return New KRAALModel(store)
    End Function

    Public Function HasUniverseWithName(universeName As String) As Boolean Implements IKRAALModel.HasUniverseWithName
        Return universes.FindByName(universeName)
    End Function

    Public Function CreateUniverse(universeName As String) As IUniverseModel Implements IKRAALModel.CreateUniverse
        Return New UniverseModel(universes.Create(universeName))
    End Function
End Class
