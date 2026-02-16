Imports System

Public Class Expense
    Public Property Description As String
    Public Property Amount As Decimal
    Public Property Category As String
    Public Property DateCreated As DateTime

    Public Sub New(desc As String, amt As Decimal, cat As String)
        Description = desc
        Amount = amt
        Category = cat
        DateCreated = DateTime.Now
    End Sub

    Public Overrides Function ToString() As String
        Return $"[{DateCreated:yyyy-MM-dd}] {Category}: {Description} - ${Amount}"
    End Function
End Class