Imports System

Module Program
    Sub Main(args As String())
        Dim expenses As New List(Of Expense)()
        Dim running As Boolean = True

        Console.WriteLine("=== Test Expense Tracker ===")

        While running
            Console.WriteLine(vbCrLf & "1. Add Expense | 2. Show All | 3. Exit")
            Dim choice = Console.ReadLine()

            Select Case choice
            Case "1"
                Console.Write("Description: ")
                Dim desc = Console.ReadLine()

                Console.Write("Amount: ")
                Dim amt As Decimal
                If Decimal.TryParse(Console.ReadLine(), amt) Then
                    Console.Write("Category: ")
                    Dim cat = Console.ReadLine()

                    expenses.Add(New Expense(desc, amt, cat))
                    Console.WriteLine("Added!")
                Else
                    Console.WriteLine("Invalid amount. Try again.")
                End If
            Case "2"
                Console.WriteLine("=== All Expenses ===")
                For Each ex In expenses
                    Console.WriteLine(ex.ToString())
                Next

            Case "3"
                running = False
            End Select
        End While
    End Sub
End Module