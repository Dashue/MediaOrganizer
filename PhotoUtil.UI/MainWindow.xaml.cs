using PhotoUtil.UI.ViewModels;
using System.Windows;
using System.Windows.Forms;

namespace PhotoUtil.UI
{
    public partial class MainWindow : Window
    {
        private FolderBrowserDialog dialog;

        public MainWindow()
        {
            InitializeComponent();

            dialog = new FolderBrowserDialog();
            DataContext = new MainViewModel();
        }

        private void SelectPath(object sender, RoutedEventArgs e)
        {
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ((MainViewModel)DataContext).Path = dialog.SelectedPath;
            }
        }
    }
}
