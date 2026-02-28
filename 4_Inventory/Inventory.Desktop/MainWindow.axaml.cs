using Avalonia.Controls;
using Inventory.Logic;

namespace Inventory.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void AddBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var manager = new InventoryManager();
        if(string.IsNullOrEmpty(ItemNameInput.Text)) return;
        string name = ItemNameInput.Text;
        if(int.TryParse(QuantityInput.Text, out int qty))
        {
            manager.AddItem(name,qty);
            LoadData();
        }
    }

    private void LoadData()
    {
        var manager = new InventoryManager();
        var items = manager.GetItems();
        InventoryList.ItemsSource = items;
    }
}