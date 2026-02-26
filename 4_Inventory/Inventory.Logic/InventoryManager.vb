Imports System.Collections.Generic
Imports Microsoft.Data.Sqlite
Imports Dapper

Public Class InventoryManager
    Private Const ConnectionString As String = "Data Source=inventory.db"

    Public Sub InitializeDatabase()
        Using conn As New SqliteConnection(ConnectionString)
            conn.Execute("CREATE TABLE IF NOT EXISTS Inventory (Id INTEGER PRIMARY KEY, Name TEXT, Qty INTEGER)")
        End Using
    End Sub

    Public Function GetItems() As IEnumerable(Of Object)
        Using conn As New SqliteConnection(ConnectionString)
            Return conn.Query("SELECT * FROM Inventory")
        End Using
    End Function
End Class
