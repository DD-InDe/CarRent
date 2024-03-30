using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CarRent.Entities.Models;

namespace CarRent.Pages.EmployeePage;

public partial class UserInfoPage : Page
{
    private User _user;

    public UserInfoPage(User user, bool canGoBack)
    {
        _user = user;
        InitializeComponent();

        BackButton.Visibility = canGoBack ? Visibility.Visible : Visibility.Collapsed;
        LicensePageButton.Visibility = user.RoleId == 3 ? Visibility.Visible : Visibility.Collapsed;
        DataContext = _user;
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();

    private void EditButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new ProfileEditPage(_user, true));

    private void LicensePageButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ClientInfoPage(_user.Client));
}