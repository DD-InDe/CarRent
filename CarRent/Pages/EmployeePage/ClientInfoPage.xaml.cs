using System.Windows;
using System.Windows.Controls;
using CarRent.Entities.Models;

namespace CarRent.Pages.EmployeePage;

public partial class ClientInfoPage : Page
{
    public ClientInfoPage(Client client)
    {
        InitializeComponent();
        DataContext = client;
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();
}