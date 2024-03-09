﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages.EmployeePage;

public partial class RequestInfoPage : Page
{
    private Request _request;
    private CustomMessageBox _messageBox;

    public RequestInfoPage(Request request)
    {
        InitializeComponent();
        _request = request;
        DataContext = request;

        CheckButtons();
    }

    private void CheckButtons()
    {
        try
        {
            switch (_request.RequestStatusId)
            {
                case 1:
                    AcceptButton.Visibility = Visibility.Visible;
                    RejectButton.Visibility = Visibility.Visible;
                    InProgressButton.Visibility = Visibility.Collapsed;
                    ExecuteButton.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    InProgressButton.Visibility = Visibility.Visible;
                    ExecuteButton.Visibility = Visibility.Collapsed;
                    AcceptButton.Visibility = Visibility.Collapsed;
                    RejectButton.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    AcceptButton.Visibility = Visibility.Collapsed;
                    RejectButton.Visibility = Visibility.Collapsed;
                    InProgressButton.Visibility = Visibility.Collapsed;
                    ExecuteButton.Visibility = Visibility.Collapsed;
                    break;
                case 6:
                    ExecuteButton.Visibility = Visibility.Visible;
                    InProgressButton.Visibility = Visibility.Collapsed;
                    AcceptButton.Visibility = Visibility.Collapsed;
                    RejectButton.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void BackButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();

    private async void AcceptButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            Request request =
                await DB.Context.Requests.FirstOrDefaultAsync(
                    c => c.CarId == _request.CarId && (c.RequestStatusId == 2 || c.RequestStatusId == 6) && c.EndDate > _request.StartDate);
            ImageBehavior.SetAnimatedSource(LoadingImage, null);

            if (request != null)
            {
                _messageBox = new CustomMessageBox(Icon.ErrorIcon, "Данный автомобиль находится в аренде в этом промежутке времени!",
                    Button.Ok);
                _messageBox.ShowDialog();
                return;
            }
            else
            {
                _messageBox = new CustomMessageBox(Icon.QuestionIcon, "Подтвердить заявку на аренду?", Button.YesNo);
                _messageBox.ShowDialog();
                if (_messageBox.Result == "Yes")
                {
                    _request.RequestStatusId = 2;
                    await DB.Context.SaveChangesAsync();
                    DataContext = null;
                    DataContext = _request;
                    CheckButtons();
                }
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async void RejectButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _messageBox = new CustomMessageBox(Icon.QuestionIcon, "Отклонить заявку на аренду?", Button.YesNo);
            _messageBox.ShowDialog();
            if (_messageBox.Result == "Yes")
            {
                _request.RequestStatusId = 3;
                await DB.Context.SaveChangesAsync();
                DataContext = null;
                DataContext = _request;
                CheckButtons();
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async void InProgressButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _messageBox = new CustomMessageBox(Icon.QuestionIcon, "Авто сдано в аренду?", Button.YesNo);
            _messageBox.ShowDialog();
            if (_messageBox.Result == "Yes")
            {
                _request.RequestStatusId = 6;
                await DB.Context.SaveChangesAsync();
                DataContext = null;
                DataContext = _request;
                CheckButtons();
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async void ExecuteButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _messageBox = new CustomMessageBox(Icon.QuestionIcon, "Завершить аренду?", Button.YesNo);
            _messageBox.ShowDialog();
            if (_messageBox.Result == "Yes")
            {
                _request.RequestStatusId = 4;
                await DB.Context.SaveChangesAsync();
                DataContext = null;
                DataContext = _request;
                CheckButtons();
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }
}