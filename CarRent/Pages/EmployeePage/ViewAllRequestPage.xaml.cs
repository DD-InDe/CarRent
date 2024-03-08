using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Pages.ClientPages;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages.EmployeePage;

public partial class ViewAllRequestPage : Page
{
    private List<Request> _requests;
    private List<RequestStatus> _statusList;
    private List<User> _clients;

    public ViewAllRequestPage()
    {
        InitializeComponent();
    }

    private async void ViewAllRequestPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (RequestListView.ItemsSource == null)
        {
            await LoadData();
            StatusComboBox.ItemsSource = _statusList;
            ClientComboBox.ItemsSource = _clients;
            StatusComboBox.SelectedIndex = 0;
            ClientComboBox.SelectedIndex = 0;
        }
        else
            UpdateData();
    }

    private async Task LoadData()
    {
        _statusList = new List<RequestStatus> { new RequestStatus { Name = "Все" } };
        _clients = new List<User> { new User { FirstName = "Все" } };
        ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
        _statusList.AddRange(await DB.Context.RequestStatuses.ToListAsync());
        _clients.AddRange(await DB.Context.Users.Where(c => c.RoleId == 3).ToListAsync());

        ImageBehavior.SetAnimatedSource(LoadingImage, null);
    }

    private void OpenFilter_OnClick(object sender, RoutedEventArgs e) => Popup.IsOpen = !Popup.IsOpen;

    private void StatusComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void ClientComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateData();

    private void UpdateData()
    {
        ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
        User selectedClient = ClientComboBox.SelectedItem as User;
        RequestStatus selectedStatus = StatusComboBox.SelectedItem as RequestStatus;

        if (selectedClient == null || selectedStatus == null)
            return;

        string searchText = SearchTextBox.Text.ToLower();

        _requests = DB.Context.Requests
            .Include(c => c.Car)
            .Include(c => c.Car.BrandModel)
            .Include(c => c.Car.BrandModel.Brand)
            .Include(c => c.Car.BrandModel.Model)
            .Include(c => c.Client)
            .Include(c => c.RequestStatus)
            .Where(c => (c.Client == selectedClient || selectedClient.FirstName == "Все") &&
                        (c.RequestStatus == selectedStatus || selectedStatus.Name == "Все") &&
                        (c.Client.FirstName.ToLower().Contains(searchText) ||
                         c.Client.LastName.ToLower().Contains(searchText) ||
                         c.Client.MiddleName.ToLower().Contains(searchText)))
            .ToList();
        RequestListView.ItemsSource = _requests;

        ImageBehavior.SetAnimatedSource(LoadingImage, null);
    }

    private void RequestListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        
        // NavigationService.Navigate(new CarEditPage(RequestListView.SelectedItem as Car));
    }
}