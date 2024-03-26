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
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages.EmployeePage;

public partial class ViewUserPage : Page
{
    private List<Role> _roles;
    private List<User> _users;

    public ViewUserPage()
    {
        InitializeComponent();
    }

    private async Task LoadData()
    {
        try
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            _roles = new List<Role> { new Role { Name = "Все" } };
            _roles.AddRange(await DB.Context.Roles.ToListAsync());
            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async Task UpdateData()
    {
        try
        {
            Role role = RoleComboBox.SelectedItem as Role;
            string search = SearchTextBox.Text.ToLower();

            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            _users = await DB.Context.Users.Include(c => c.UserNavigation).Include(c => c.Role).Where(c =>
                (c.Role == role || role.Name == "Все") &&
                (c.FirstName.ToLower().Contains(search) || c.LastName.ToLower().Contains(search) ||
                 c.MiddleName.ToLower().Contains(search) || c.UserNavigation.Login.ToLower().Contains(search))).ToListAsync();

            UserListView.ItemsSource = null;
            UserListView.ItemsSource = _users;
            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => await UpdateData();

    private void OpenFilter_OnClick(object sender, RoutedEventArgs e) => Popup.IsOpen = !Popup.IsOpen;

    private async void RoleComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => await UpdateData();

    private void UserListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
    }

    private async void ViewUserPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            if (UserListView.ItemsSource == null)
            {
                await LoadData();
                RoleComboBox.ItemsSource = _roles;
                RoleComboBox.SelectedIndex = 0;
            }
            else
             await   UpdateData();
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }
}