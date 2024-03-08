using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WpfAnimatedGif;
using Xceed.Wpf.Toolkit;

namespace CarRent.UserControls.EmployeePages;

public partial class CarEditControl : UserControl
{
    private Car _car;
    private CustomMessageBox messageBox;
    private List<Object> _requiredFields;

    public CarEditControl()
    {
        _car = new Car();
        InitializeComponent();
    }

    public CarEditControl(Car car)
    {
        _car = car;
        InitializeComponent();
    }

    private void CarPhotoImage_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "png,jpg,jpeg |*.png;*.jpg;*.jpeg"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            CarPhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            _car.Photo = File.ReadAllBytes(openFileDialog.FileName);
        }
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService navigationService = NavigationService.GetNavigationService(this);
        navigationService.Navigate(new CarViewControl());
    }

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (!CheckFields())
            return;

        if (_car.CarId == 0)
        {
            DB.Context.Cars.Add(_car);
            await DB.Context.SaveChangesAsync();
        }
        else
            await DB.Context.SaveChangesAsync();
    }

    private bool CheckFields()
    {
        if (!String.IsNullOrWhiteSpace(CarPriceTextBox.Text) &&
            !String.IsNullOrWhiteSpace(RentPriceTextBox.Text) &&
            !String.IsNullOrWhiteSpace(VinNumTextBox.Text))
            return true;

        messageBox = new CustomMessageBox(Icon.WarningIcon, "Пожалуйста, заполните все поля!", Button.Ok);
        messageBox.ShowDialog();

        foreach (var field in _requiredFields)
            HighlightingFields(field);

        return false;
    }

    private void HighlightingFields(object sender)
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
            case "ComboBox":
                ComboBox comboBox = (sender as ComboBox)!;
                if (comboBox.SelectedItem != null)
                    comboBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                else
                    comboBox.BorderBrush = Brushes.DarkGray;
                break;
        }
    }

    private async void CarEditControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
        BrandModelComboBox.ItemsSource = await DB.Context.BrandModels.ToListAsync();
        StatusComboBox.ItemsSource = await DB.Context.CarStatuses.ToListAsync();

        _requiredFields = new List<object>
        {
            VinNumTextBox,
            CarPriceTextBox,
            RentPriceTextBox,
            StatusComboBox,
            BrandModelComboBox
        };
        ImageBehavior.SetAnimatedSource(LoadingImage, null);

        if (_car.Photo == null)
            _car.Photo = File.ReadAllBytes(@"../../../Resources/Car.png");

        DataContext = _car;
    }

    private void CarPriceTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = "1234567890".IndexOf(e.Text) < 0;
    }

    private void VinNumTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string specialCharacterPattern = "[0-9A-Z]";
        e.Handled = !Regex.IsMatch(e.Text, specialCharacterPattern);
    }
}