using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Aspose.Email;
using Aspose.Email.Tools.Verifications;
using CarRent.Entities;
using CarRent.Models;
using Xceed.Wpf.Toolkit;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace CarRent.Pages;

public partial class RegPage : Page
{
    private DispatcherTimer _timer;
    private DateTime _time;

    public RegPage()
    {
        InitializeComponent();
    }

    private void RegButton_OnClick(object sender, RoutedEventArgs e)
    {
        string firstName = FNameTextBox.Text;
        string lastName = LNameTextBox.Text;
        string middleName = MNameTextBox.Text;
        string email = EmailTextBox.Text;
        string login = LoginTextBox.Text;
        string password = HiddenPasswordBox.Password;

        if (!String.IsNullOrWhiteSpace(firstName) &&
            !String.IsNullOrWhiteSpace(lastName) &&
            !String.IsNullOrWhiteSpace(middleName) &&
            !String.IsNullOrWhiteSpace(lastName) &&
            !String.IsNullOrWhiteSpace(login) &&
            !String.IsNullOrWhiteSpace(password) &&
            PhoneTextBox.IsMaskCompleted)
        {
        }
        else
        {
            CustomMessageBox messageBox = new CustomMessageBox("Поля, отмеченные звездочкой, не могут быть пустыми!", "Ok");
            messageBox.Show();
        }
    }

    private bool CheckLogin(string login)
    {
        return DB._context.Accounts.Any(c => c.Login == login);
    }

    private void RusTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) =>
        e.Handled = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text.ToUpper()) < 0;

    private void NoneRusTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) =>
        e.Handled = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".IndexOf(e.Text.ToUpper()) > 0;

    private void ShowPassImage_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (HiddenPasswordBox.IsVisible)
        {
            HiddenPasswordBox.Visibility = Visibility.Collapsed;
            ShowedPasswordBox.Visibility = Visibility.Visible;
            ShowedPasswordBox.Text = HiddenPasswordBox.Password;
            _time = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Tick += TickTimer;
            _timer.Start();
        }
        else
        {
            ChangeVisibility();
            _timer.Stop();
        }
    }

    private void ChangeVisibility()
    {
        HiddenPasswordBox.Visibility = Visibility.Visible;
        ShowedPasswordBox.Visibility = Visibility.Collapsed;
        HiddenPasswordBox.Password = ShowedPasswordBox.Text;
    }

    private void TickTimer(object sender, EventArgs e)
    {
        var f = DateTime.Now - _time;
        if (f.Seconds >= 5)
        {
            ChangeVisibility();
            _timer.Stop();
        }
    }

    private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
    {
        string[] senderType = sender.GetType().ToString().Split(".");
        switch (senderType[senderType.Length - 1])
        {
            case "TextBox":
                TextBox textBox = sender as TextBox;
                if (String.IsNullOrWhiteSpace(textBox.Text))
                    textBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                else
                    textBox.BorderBrush = Brushes.DarkGray;

                break;
            case "MaskedTextBox":
                MaskedTextBox maskedTextBox = sender as MaskedTextBox;
                if (!maskedTextBox.IsMaskCompleted)
                    maskedTextBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                else
                    maskedTextBox.BorderBrush = Brushes.DarkGray;

                break;
            case "PasswordBox":
                PasswordBox passwordBox = sender as PasswordBox;
                if (String.IsNullOrWhiteSpace(passwordBox.Password))
                    passwordBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                else
                    passwordBox.BorderBrush = Brushes.DarkGray;

                break;
        }
    }
}