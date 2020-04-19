using BookKeeper.Wpf.UI.Services;
using BookKeeper.Wpf.UI.ViewModels;
using System.Windows;

namespace BookKeeper.Wpf.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MenuViewModel(new DialogService());
        }
    }
}