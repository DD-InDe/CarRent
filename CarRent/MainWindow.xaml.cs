using System.Windows;
using System.Windows.Navigation;
using CarRent.Pages;

namespace CarRent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            
        }
    }
}