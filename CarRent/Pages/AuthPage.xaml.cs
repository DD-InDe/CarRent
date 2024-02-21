using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages;

public partial class AuthPage : Page
{
    private CustomMessageBox? _messageBox;
    
    public AuthPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        string login = LoginTextBox.Text;
        string pass = PasswordBox.Password;

        if (!String.IsNullOrWhiteSpace(login) && !String.IsNullOrWhiteSpace(pass))
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            User? user = await DB._context.Users.Include(c => c.UserNavigation).FirstOrDefaultAsync(c => c.UserNavigation.Login == login);
            ImageBehavior.SetAnimatedSource(LoadingImage, null);

            if (user != null && user.UserNavigation.Password != pass)
            {
                _messageBox = new CustomMessageBox(Icon.WrongPassIcon,
                    "Вы ввели неверный пароль. Проверьте корректность Ваших данных!",
                    Button.Ok);
                _messageBox.ShowDialog();
            }
            else if (user != null & user!.UserNavigation.Password == pass)
            {
                _messageBox = new CustomMessageBox(Icon.SuccessIcon,
                    "Вы успешно авторизировались в системе!",
                    Button.Ok);
                _messageBox.ShowDialog();
                AddWindow();
            }
            else
            {
                _messageBox = new CustomMessageBox(Icon.UserNotFoundIcon,
                    "Пользователь с такими данными не найден. Проверьте корректность Ваших данных!",
                    Button.Ok);
                _messageBox.ShowDialog();
            }
        }
        else
        {
            _messageBox = new CustomMessageBox(Icon.WarningIcon,
                "Поля не могут быть пустыми!",
                Button.Ok);
            _messageBox.ShowDialog();
        }
    }

    private void GuestButton_OnClick(object sender, RoutedEventArgs e) => AddWindow();

    private void AddWindow()
    {
        var window = Application.Current.MainWindow;
        Application.Current.MainWindow = new MainWindow();
        Application.Current.MainWindow.Show();
        window.Close();
    }
}