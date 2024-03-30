using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;
using Xceed.Wpf.Toolkit;

namespace CarRent.Pages;

public partial class RegPage : Page
{
    private readonly List<Object> _requiredFields;
    private CustomMessageBox? messageBox;

    public RegPage()
    {
        InitializeComponent();

        _requiredFields = new List<object>
        {
            FNameTextBox,
            LNameTextBox,
            PhoneTextBox,
            LoginTextBox,
            HiddenPasswordBox
        };
    }

    private async void RegButton_OnClick(object sender, RoutedEventArgs e)
    {
        string firstName = FNameTextBox.Text;
        string lastName = LNameTextBox.Text;
        string middleName = MNameTextBox.Text;
        string email = EmailTextBox.Text;
        string login = LoginTextBox.Text;
        string password = HiddenPasswordBox.Password;

        if (ValidateData.CheckFields(_requiredFields))
            if (await ValidateData.CheckLogin(login) && ValidateData.CheckEmail(email))
            {
                ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
                try
                {
                    Account account = new Account { Login = login, Password = password };
                    DB.Context.Accounts.Add(account);
                    await DB.Context.SaveChangesAsync();

                    account = await DB.Context.Accounts.FirstAsync(c => c.Login == login && c.Password == password);
                    User user = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        MiddleName = middleName,
                        Email = email,
                        Phone = PhoneTextBox.Text,
                        RoleId = 3,
                        UserId = account.AccountId
                    };
                    DB.Context.Users.Add(user);
                    await DB.Context.SaveChangesAsync();
                    messageBox = new CustomMessageBox(Icon.SuccessIcon, "Вы зарегистрировались!", Button.Ok);
                    messageBox.ShowDialog();
                    NavigationService.GoBack();
                }
                catch (Exception exception)
                {
                    CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
                    messageBox.ShowDialog();
                }

                ImageBehavior.SetAnimatedSource(LoadingImage, null);
            }
    }

    private void RusTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) =>
        e.Handled = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text.ToUpper()) < 0;

    private void NoneRusTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) =>
        e.Handled = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text.ToUpper()) > 0;


    private void ChangeVisibility()
    {
        HiddenPasswordBox.Visibility = Visibility.Visible;
        ShowedPasswordBox.Visibility = Visibility.Collapsed;
        HiddenPasswordBox.Password = ShowedPasswordBox.Text;
    }

    private void TextBox_OnLostFocus(object sender, RoutedEventArgs e) => ValidateData.HighlightingFields(sender);

    private void ShowPassImage_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        HiddenPasswordBox.Visibility = Visibility.Collapsed;
        ShowedPasswordBox.Visibility = Visibility.Visible;
        ShowedPasswordBox.Text = HiddenPasswordBox.Password;
    }

    private void ShowPassImage_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => ChangeVisibility();

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();
}