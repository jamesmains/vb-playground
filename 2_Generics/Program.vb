Imports System

Module Program
    Sub Main(args As String())
        Dim stringResult As New DataResult(Of String)("Success!", True, "All good.")
        Dim intResult As New DataResult(Of Integer)(42, True, "Number found")

        Console.WriteLine(New String("-"c, 20))
        PrintData(Of String)(stringResult.Payload)
        PrintData(Of Integer)(intResult.Payload)
        PrintData(Of Boolean)(True)
        PrintData(100.50)
        
    End Sub
    
    Sub PrintData(Of T)(item As T)
        Console.WriteLine($"Data Type: {NameOf(T)}")
        Console.WriteLine($"Value: {item}")
        Console.WriteLine(New String("-"c, 20))
    End Sub
End Module
