using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CarRent.Entities;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Pages;

public partial class AuthPage : Page
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        string login = LoginTextBox.Text;
        string pass = PasswordBox.Password;

        if (!String.IsNullOrWhiteSpace(login) && !String.IsNullOrWhiteSpace(pass))
        {
            User? user = DB._context.Users.Include(c => c.UserNavigation).FirstOrDefault(c => c.UserNavigation.Login == login);
            if (user != null && user.UserNavigation.Password != pass)
                MessageBox.Show("Вы ввели неверный пароль. Проверьте корректность Ваших данных!");
            else if (user != null & user.UserNavigation.Password == pass)
                MessageBox.Show("Вы успешно авторизировались в системе!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            else
                MessageBox.Show("Пользователь с такими данными не найден. Проверьте корректность Ваших данных!");
        }
    }
}