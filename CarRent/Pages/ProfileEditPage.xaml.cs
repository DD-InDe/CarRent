using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Pages.ClientPages;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WpfAnimatedGif;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace CarRent.Pages;

public partial class ProfileEditPage : Page
{
    private List<Object> _requiredFields;
    private CustomMessageBox? messageBox;
    private User _user;
    private string oldLogin;
    private bool _canGoBack;

    public ProfileEditPage(bool canGoBack)
    {
        _user = new User()
        {
            UserNavigation = new Account(),
            Passport = new Passport()
        };
        _canGoBack = canGoBack;
        DeleteButton.Visibility = Visibility.Hidden;

        InitializeComponent();

        _requiredFields = new List<object>
        {
            FNameTextBox,
            LNameTextBox,
            PhoneTextBox,
            LoginTextBox,
            PassSTextBox,
            PassNTextBox,
            PassIssueDatePicker,
            IssueByTextBox,
            RoleComboBox
        };
    }

    public ProfileEditPage(User user, bool canGoBack)
    {
        _user = user;
        _canGoBack = canGoBack;
        oldLogin = user.UserNavigation.Login;
        InitializeComponent();

        PhoneTextBox.Text = user.PhoneOnlyNumbers;
        DeleteButton.Visibility = Visibility.Visible;

        _requiredFields = new List<object>
        {
            FNameTextBox,
            LNameTextBox,
            PhoneTextBox,
            LoginTextBox,
            PassSTextBox,
            PassNTextBox,
            PassIssueDatePicker,
            IssueByTextBox,
        };
    }


    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        string firstName = FNameTextBox.Text;
        string lastName = LNameTextBox.Text;
        string email = EmailTextBox.Text;
        string newLogin = LoginTextBox.Text;
        string password = HiddenPasswordBox.Password;

        if (ValidateData.CheckFields(_requiredFields))
            if (_user.UserId == 0)
            {
                if (await ValidateData.CheckLogin(newLogin) && ValidateData.CheckEmail(email))
                {
                    ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
                    try
                    {
                        _user.Phone = PhoneTextBox.Text;
                        _user.UserNavigation.Password = HiddenPasswordBox.Password;
                        DB.Context.Users.Add(_user);
                        await DB.Context.SaveChangesAsync();
                        messageBox = new CustomMessageBox(Icon.SuccessIcon, "Пользователь добавлен!", Button.Ok);
                        messageBox.ShowDialog();
                    }
                    catch (Exception exception)
                    {
                        CustomMessageBox messageBox =
                            new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
                        messageBox.ShowDialog();
                    }

                    ImageBehavior.SetAnimatedSource(LoadingImage, null);
                }
            }
            else
            {
                if (newLogin != oldLogin
                        ? await ValidateData.CheckLogin(newLogin) && ValidateData.CheckEmail(email)
                        : ValidateData.CheckEmail(email))
                {
                    ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
                    try
                    {
                        _user.Phone = PhoneTextBox.Text;
                        if (password != String.Empty)
                            _user.UserNavigation.Password = password;

                        await DB.Context.SaveChangesAsync();
                        messageBox = new CustomMessageBox(Icon.SuccessIcon, "Данные обновлены!", Button.Ok);
                        messageBox.ShowDialog();
                    }
                    catch (Exception exception)
                    {
                        CustomMessageBox messageBox =
                            new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
                        messageBox.ShowDialog();
                    }

                    ImageBehavior.SetAnimatedSource(LoadingImage, null);
                }
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

    private void PassPhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog fileDialog = new OpenFileDialog
        {
            Filter = "Images (jpg, png, jpeg)| *.jpg; *.png; *.jpeg"
        };
        if (fileDialog.ShowDialog() == true)
        {
            _user.Passport.Photo = File.ReadAllBytes(fileDialog.FileName);
            PassImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
        }
    }

    private void LicensePageButton_OnClick(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new ClientEditPage(_user.Client));

    private void ProfileEditPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        RoleComboBox.ItemsSource = DB.Context.Roles.ToList();

        RolePanel.Visibility = ((App)App.Current).GetCurrentUser().RoleId == 1 && _user.RoleId != 1
            ? Visibility.Visible
            : Visibility.Collapsed;
        BackButton.Visibility = _canGoBack ? Visibility.Visible : Visibility.Collapsed;
        LicensePageButton.Visibility = _user.RoleId == 3 ? Visibility.Visible : Visibility.Collapsed;

        DataContext = _user;
    }

    private async void DeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_user.RoleId == 1)
            {
                messageBox =
                    new CustomMessageBox(Icon.ErrorIcon, $"Нельзя удалить администратора!", Button.Ok);
                messageBox.ShowDialog();
            }

            if (await DB.Context.Requests.FirstOrDefaultAsync(c =>
                    c.ClientId == _user.UserId && (c.RequestStatusId != 2 && c.RequestStatusId != 6)) == null)
            {
                messageBox = new CustomMessageBox(Icon.QuestionIcon, "Вы точно хотите удалить пользователя?", Button.YesNo);
                messageBox.ShowDialog();
                if (messageBox.Result == "Yes")
                {
                    DB.Context.Accounts.Remove(_user.UserNavigation);
                    await DB.Context.SaveChangesAsync();
                    messageBox = new CustomMessageBox(Icon.SuccessIcon, "Пользователь удален!", Button.Ok);
                    messageBox.ShowDialog();
                    NavigationService.GoBack();
                }
            }
        }
        catch (Exception exception)
        {
            messageBox =
                new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }
}