Imports System

Module Program
    Sub Main(args As String())
        ' Init database
        Database.Initialize()

        Dim running As Boolean = True
        Console.WriteLine("=== SQLite Expense Tracker ===")

        While running
            Console.WriteLine(vbCrLf & "1.) Add | 2.) Show All | 3.) Exit")
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

                    Dim newEx As New Expense(desc, amt, cat)
                    Database.SaveExpense(newEx)
                    Console.WriteLine("Added & Saved to Database!")
                Else
                    Console.WriteLine("Invalid amount. Try again.")
                End If
            Case "2"
                Console.WriteLine("=== All Expenses ===")
                Dim dbExpense = Database.GetAllExpenses()
                For Each ex In dbExpense
                    Console.WriteLine(ex.ToString())
                Next

            Case "3"
                running = False
            End Select
        End While
    End Sub
End Module
