using Avalonia.Controls;
using Inventory.Logic;

namespace Inventory.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var manager = new InventoryManager();
        manager.InitializeDatabase();
    }
}