using PhotoUtil.UI.ViewModels;
using System.Windows;

namespace PhotoUtil.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}
