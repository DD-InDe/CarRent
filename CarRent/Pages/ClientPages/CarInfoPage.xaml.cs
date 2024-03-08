using System.Windows;
using System.Windows.Controls;
using CarRent.Entities.Models;

namespace CarRent.Pages.ClientPages;

public partial class CarInfoPage : Page
{
    public CarInfoPage(Car car)
    {
        InitializeComponent();

        if (((App)Application.Current).GetCurrentUser() == null)
            AddRequestButton.Visibility = Visibility.Collapsed;
        if (car.CarStatusId == 3)
            AddRequestButton.IsEnabled = false;

        DataContext = car;
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();

    private void AddRequestButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new RequestAddPage(DataContext as Car));
}