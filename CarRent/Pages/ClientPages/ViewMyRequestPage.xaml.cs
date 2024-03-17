using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Pages.EmployeePage;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages.ClientPages;

public partial class ViewMyRequestPage : Page
{
    private List<Request> _requests;
    private List<RequestStatus> _statusList;
    private User _user;

    public ViewMyRequestPage(User user)
    {
        _user = user;
        InitializeComponent();
    }

    private async void ViewMyRequestPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            if (RequestListView.ItemsSource == null)
            {
                await LoadData();
                StatusComboBox.ItemsSource = _statusList;
                StatusComboBox.SelectedIndex = 0;
            }
            else
                UpdateData();
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async Task LoadData()
    {
        try
        {
            _statusList = new List<RequestStatus> { new RequestStatus { Name = "Все" } };
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            _statusList.AddRange(await DB.Context.RequestStatuses.ToListAsync());
            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void OpenFilter_OnClick(object sender, RoutedEventArgs e) => Popup.IsOpen = !Popup.IsOpen;

    private void StatusComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateData();

    private async void UpdateData()
    {
        try
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            RequestStatus selectedStatus = StatusComboBox.SelectedItem as RequestStatus;

            string searchText = SearchTextBox.Text.ToLower();

            _requests = await DB.Context.Requests
                .Include(c => c.Car)
                .Include(c => c.Car.BrandModel)
                .Include(c => c.Car.BrandModel.Brand)
                .Include(c => c.Car.BrandModel.Model)
                .Include(c => c.Client)
                .Include(c => c.RequestStatus)
                .Where(c => (c.RequestStatus == selectedStatus || selectedStatus.Name == "Все") &&
                            (c.Car.BrandModel.Model.Name.ToLower().Contains(searchText) ||
                             c.Car.BrandModel.Brand.Name.ToLower().Contains(searchText) ||
                             c.Car.BrandModel.Class.Name.ToLower().Contains(searchText))
                            && c.ClientId == _user.UserId).ToListAsync();
            RequestListView.ItemsSource = _requests;

            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void RequestListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        NavigationService.Navigate(new RequestInfoPage(RequestListView.SelectedItem as Request, _user));
    }
}