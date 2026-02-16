Public Class DataResult(Of T)
    Public Property Success As Boolean
    Public Property Message As String
    Public Property Payload As T ' Generic type to hold any data

    Public Sub New(data As T, isSuccess As Boolean, msg As String)
        Payload = data
        Success = isSuccess
        Message = msg
    End Sub
End Class