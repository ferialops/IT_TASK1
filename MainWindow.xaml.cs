using System.Windows;
using SetApp.ViewModels;

namespace SetApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SetViewModel<string>();
        }
    }
}
