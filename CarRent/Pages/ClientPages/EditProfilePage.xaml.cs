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

public partial class EditProfilePage : Page
{
    private readonly List<Object> _requiredFields;
    private CustomMessageBox? messageBox;
    private User _user;
    private Action action;

    public EditProfilePage(User user, Action action)
    {
        _user = user;
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

    public EditProfilePage(Action action)
    {
        _user = new User();
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

        if (CheckFields(firstName, lastName, login, password))
            if (await CheckLogin(login) && CheckEmail(email))
            {
                ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
                try
                {
                    if (_user.UserId == 0)
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
                    }
                    else
                    {
                        await DB.Context.SaveChangesAsync();
                    }

                    messageBox = new CustomMessageBox(Icon.SuccessIcon, "Данные обновлены!", Button.Ok);
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

    private bool CheckFields(string firstName, string lastName, string login, string password)
    {
        try
        {
            if (!String.IsNullOrWhiteSpace(firstName) &&
                !String.IsNullOrWhiteSpace(lastName) &&
                !String.IsNullOrWhiteSpace(login) &&
                !String.IsNullOrWhiteSpace(password) &&
                PhoneTextBox.IsMaskCompleted)
                return true;

            messageBox = new CustomMessageBox(Icon.WarningIcon, "Пожалуйста, заполните все поля!", Button.Ok);
            messageBox.ShowDialog();

            foreach (var field in _requiredFields)
                HighlightingFields(field);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }

        return false;
    }

    private async Task<bool> CheckLogin(string login)
    {
        try
        {
            bool exist = await DB.Context.Accounts.AnyAsync(c => c.Login == login);
            if (exist)
            {
                CustomMessageBox messageBox = new CustomMessageBox(Icon.WarningIcon, "Этот логин уже занят, придумайте другой.", Button.Ok);
                messageBox.Show();
                return false;
            }

            return true;
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }

        return false;
    }

    private static bool CheckEmail(string email)
    {
        try
        {
            if (String.IsNullOrWhiteSpace(email))
                return true;
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address == email)
                return true;
            CustomMessageBox messageBox = new CustomMessageBox(Icon.WarningIcon, "Почта не соответствует формату!", Button.Ok);
            messageBox.ShowDialog();
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }

        return false;
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

    private void HighlightingFields(object sender)
    {
        try
        {
            string[] senderType = sender.GetType().ToString().Split(".");
            switch (senderType[senderType.Length - 1])
            {
                case "TextBox":
                    TextBox textBox = (sender as TextBox)!;
                    if (String.IsNullOrWhiteSpace(textBox.Text))
                        textBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                    else
                        textBox.BorderBrush = Brushes.DarkGray;

                    break;
                case "MaskedTextBox":
                    MaskedTextBox maskedTextBox = (sender as MaskedTextBox)!;
                    if (!maskedTextBox.IsMaskCompleted)
                        maskedTextBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                    else
                        maskedTextBox.BorderBrush = Brushes.DarkGray;

                    break;
                case "PasswordBox":
                    PasswordBox passwordBox = (sender as PasswordBox)!;
                    if (String.IsNullOrWhiteSpace(passwordBox.Password))
                        passwordBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                    else
                        passwordBox.BorderBrush = Brushes.DarkGray;

                    break;
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void TextBox_OnLostFocus(object sender, RoutedEventArgs e) => HighlightingFields(sender);

    private void ShowPassImage_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        HiddenPasswordBox.Visibility = Visibility.Collapsed;
        ShowedPasswordBox.Visibility = Visibility.Visible;
        ShowedPasswordBox.Text = HiddenPasswordBox.Password;
    }

    private void ShowPassImage_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => ChangeVisibility();

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();

    private void EditProfilePage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            if (action == Action.Registration)
            {
                
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }
}