Imports Microsoft.Data.Sqlite
Imports Dapper

Public Module Database
    ' Create the database file in project folder
    Private Const ConnectionString As String = "Data Source=expenses.db"

    Public Sub Initialize()
        Using conn As New SqliteConnection(ConnectionString)
            ' Create the table if it doesn't exist
            Dim sql =   "CREATE TABLE IF NOT EXISTS Expenses (" &
                        "Id INTEGER PRIMARY KEY AUTOINCREMENT," &
                        "Description TEXT," &
                        "Amount DECIMAL," &
                        "Category TEXT," &
                        "DateCreated DATETIME)"
            conn.Execute(sql)
        End Using
    End Sub

    Public Sub SaveExpense(ex As Expense)
        Using conn As New SqliteConnection(ConnectionString)
            Dim sql =   "INSERT INTO Expenses (Description, Amount, Category, DateCreated) " &
                        "VALUES (@Description, @Amount, @Category, @DateCreated)"
            conn.Execute(sql, ex)
        End Using
    End Sub

    Public Function GetAllExpenses() As IEnumerable(Of Expense)
        Using conn As New SqliteConnection(ConnectionString)
            Return conn.Query(Of Expense)("SELECT * FROM Expenses")
        End Using
    End Function
End Module