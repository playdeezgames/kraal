Public Interface IStars
    ReadOnly Property All As IEnumerable(Of IStar)
    ReadOnly Property Count As Integer
    Function Create(starName As String, starX As Double, starY As Double, starZ As Double) As IStar
End Interface
