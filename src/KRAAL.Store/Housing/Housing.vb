Friend Class Housing
    Implements IHousing
    Sub New(housingId As Integer)
        Me.HousingId = housingId
    End Sub

    Public ReadOnly Property HousingId As Integer Implements IHousing.HousingId
End Class
