using System;
using Avalonia.Controls;
using Inventory.Logic;

namespace Inventory.Desktop;

public partial class MainWindow : Window
{
    private static InventoryManager _inventoryManager = new();
    private static string[] RandomNames =
    {
        "Verbose",
        "Titan's",
        "Shoe",
        "Laces",
        "Unwanted",
        "Flower",
        "Olympic",
        "Controller",
        "Box"
    };

    public MainWindow()
    {
        InitializeComponent();
        _inventoryManager.InitializeDatabase();
        LoadData();
    }

    private void AddBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(ItemNameInput.Text)) return;
        string name = ItemNameInput.Text;
        if (int.TryParse(QuantityInput.Text, out int qty))
        {
            _inventoryManager.AddItem(name, qty);
            LoadData();
        }
    }

    private void DeleteBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var button = (Button)sender;

        if (button.CommandParameter is Item itemToDelete)
        {
            _inventoryManager.DeleteItem(itemToDelete.Id);

            LoadData();
        }
    }

    private void SearchText_Changed(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoadData();
    }

    private void JunkBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Random random = new();
        for (int i = 0; i < 100; i++)
        {
            string first_name = RandomNames[random.Next() % RandomNames.Length];
            string second_name = RandomNames[random.Next() % RandomNames.Length];
            int quantity = random.Next() % 255;
            _inventoryManager.AddItem(first_name + " " + second_name, quantity);
        }
        LoadData();

    }

    private void DeleteAllBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _inventoryManager.DeleteAllItems();
        _inventoryManager.InitializeDatabase();
        LoadData();

    }

    private void LoadData()
    {
        var items = _inventoryManager.SearchItems(SearchItemInput.Text);
        InventoryList.ItemsSource = items;
    }
}