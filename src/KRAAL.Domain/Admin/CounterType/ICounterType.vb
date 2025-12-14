Public Interface ICounterType
    ReadOnly Property CounterTypeId As Integer
    Property CounterTypeName As String
    ReadOnly Property CounterTypes As ICounterTypes
    Sub Remove()
End Interface
