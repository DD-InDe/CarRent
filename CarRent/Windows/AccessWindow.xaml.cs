using System.Windows;
using System.Windows.Navigation;
using CarRent.Pages;

namespace CarRent
{
    /// <summary>
    /// Interaction logic for AccessWindow.xaml
    /// </summary>
    public partial class AccessWindow : Window
    {
        public AccessWindow()
        {
            InitializeComponent();
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (MainFrame.CanGoBack)
                BackButton.Visibility = Visibility.Visible;
            else
                BackButton.Visibility = Visibility.Hidden;
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e) => MainFrame.GoBack();
    }
}