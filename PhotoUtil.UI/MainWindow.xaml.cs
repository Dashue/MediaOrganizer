using PhotoUtil.UI.ViewModels;
using System.Windows;
using System.Windows.Forms;

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
