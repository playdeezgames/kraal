Imports TGGD.Persistence

Public Interface IStar
    Property StarName As String
    ReadOnly Property StarId As Integer
    ReadOnly Property StarX As Double
    ReadOnly Property StarY As Double
    ReadOnly Property StarZ As Double
    ReadOnly Property XYZ As IXYZ
End Interface
