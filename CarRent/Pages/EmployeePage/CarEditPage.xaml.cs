﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WpfAnimatedGif;
using Xceed.Wpf.Toolkit;

namespace CarRent.Pages;

public partial class CarEditPage : Page
{
    private Car _car;
    private CustomMessageBox messageBox;
    private List<Object> _requiredFields;

    public CarEditPage()
    {
        _car = new Car();
        InitializeComponent();
    }

    public CarEditPage(Car car)
    {
        _car = car;
        InitializeComponent();
    }

    private void CarPhotoImage_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        try
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
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async void CarEditPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
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
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void CarPriceTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = "1234567890".IndexOf(e.Text) < 0;
    }

    private void VinNumTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string specialCharacterPattern = "[A-Za-z0-9]";
        e.Handled = !Regex.IsMatch(e.Text, specialCharacterPattern);
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
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
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private bool CheckFields()
    {
        try
        {
            if (!String.IsNullOrWhiteSpace(CarPriceTextBox.Text) &&
                !String.IsNullOrWhiteSpace(RentPriceTextBox.Text) &&
                !String.IsNullOrWhiteSpace(VinNumTextBox.Text))
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
                case "ComboBox":
                    ComboBox comboBox = (sender as ComboBox)!;
                    if (comboBox.SelectedItem != null)
                        comboBox.BorderBrush = (Brush)TryFindResource("RedBrush");
                    else
                        comboBox.BorderBrush = Brushes.DarkGray;
                    break;
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }
}