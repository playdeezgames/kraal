Friend Class HousingDTO
    Implements IHousingDTO
    Sub New(housingId As Integer)
        Me.HousingId = housingId
    End Sub

    Public ReadOnly Property HousingId As Integer Implements IHousingDTO.HousingId
End Class
