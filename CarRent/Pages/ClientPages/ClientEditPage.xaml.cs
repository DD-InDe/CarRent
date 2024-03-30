using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.Win32;
using WpfAnimatedGif;

namespace CarRent.Pages.ClientPages;

public partial class ClientEditPage : Page
{
    private readonly List<Object> _requiredFields;
    private CustomMessageBox? messageBox;
    private Client _client;


    public ClientEditPage(Client client)
    {
        _client = client;
        InitializeComponent();


        DataContext = client;

        _requiredFields = new List<object>
        {
            LicenseNumTextBox,
            LicenseExpirationDatePicker,
            LicenseExpirationDatePicker,
            AddressTextBox,
            MailAddressTextBox
        };
    }

    private void TextBox_OnLostFocus(object sender, RoutedEventArgs e) => ValidateData.HighlightingFields(sender);

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (ValidateData.CheckFields(_requiredFields))
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            try
            {
                await DB.Context.SaveChangesAsync();
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

    private void LicensePhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        OpenFileDialog fileDialog = new OpenFileDialog
        {
            Filter = "Images (jpg, png, jpeg)| *.jpg; *.png; *.jpeg"
        };
        if (fileDialog.ShowDialog() == true)
        {
            _client.DriverLicense.Photo = File.ReadAllBytes(fileDialog.FileName);
            LicenseImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
        }
    }

    private void MailAddressTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) =>
        e.Handled = "1234567890".IndexOf(e.Text) < 0;
}