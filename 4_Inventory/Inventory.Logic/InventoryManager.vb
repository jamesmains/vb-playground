Imports System.Collections.Generic
Imports Microsoft.Data.Sqlite
Imports Dapper

Public Class Item

Public Property Id As Integer 
Public Property Name As String
Public Property Quantity As Integer

Public ReadOnly Property StockStatus As String
Get
Return If(Quantity > 0, "In Stock", "Out of Stock")
End Get
End Property

Public ReadOnly Property StockStatusColor As String
Get
Return If(Quantity > 0, "green", "red")
End Get
End Property

End Class

Public Class InventoryManager
Private Const ConnectionString As String = "Data Source=inventory.db"

' Create Inventory table If it doesn't exist
Public Sub InitializeDatabase()
    Using conn As New SqliteConnection(ConnectionString)
    Dim sql = "CREATE TABLE If Not EXISTS Inventory (" &
    "Id INTEGER PRIMARY KEY AUTOINCREMENT, "&
    "Name TEXT, " &
    "Quantity INTEGER)"
    conn.Execute(sql)
    End Using
End Sub

Public Sub AddItem(name As String, qty As Integer)
    Using conn As New SqliteConnection(ConnectionString)
    Dim sql = "INSERT INTO Inventory (Name, Quantity) VALUES (@Name, @Quantity)"
    conn.Execute(sql, New With {Key .Name = name, Key .Quantity = qty})
    End Using
End Sub

Public Sub DeleteItem(id As Integer)
    Using conn As New SqliteConnection(ConnectionString)
    Dim sql = "DELETE FROM Inventory WHERE Id = @Id"
    conn.Execute(sql, New With {Key .Id = id})
    End Using
End Sub

Public Function SearchItems(searchTerm As String) As IEnumerable(Of Item)
    Dim allItems = GetItems()
    If String.IsNullOrWhiteSpace(searchTerm) Then Return allItems
        Return allItems.Where(Function(i) i.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList()
End Function

' Get ALL Items from Inventory table
Public Function GetItems() As IEnumerable(Of Item)
    Using conn As New SqliteConnection(ConnectionString)
    Return conn.Query(Of Item)("Select * FROM Inventory")
    End Using
End Function

Public Sub DeleteAllItems()
    Using conn As New SqliteConnection(ConnectionString)
        conn.Execute("DROP TABLE Inventory")
    End Using
End Sub

End Class
