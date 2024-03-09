using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Pages.ClientPages;

public partial class RequestAddPage : Page
{
    private Car _car;

    public RequestAddPage(Car car)
    {
        _car = car;
        InitializeComponent();
    }

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        CustomMessageBox messageBox;
        try
        {
            Request request = new Request()
            {
                Car = _car,
                Client = ((App)Application.Current).GetCurrentUser(),
                StartDate = DateStartDatePicker.SelectedDate,
                EndDate = DateEndDatePicker.SelectedDate,
                RequestStatusId = 1,
                TotalPrice = Convert.ToInt32(TotalPriceTextBlock.Text)
            };
            DB.Context.Requests.Add(request);
            await DB.Context.SaveChangesAsync();

            messageBox = new CustomMessageBox(Icon.SuccessIcon, $"Данные сохранены!", Button.Ok);
            messageBox.ShowDialog();
            NavigationService.GoBack();
        }
        catch (Exception exception)
        {
            messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void DateStartDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            DateEndDatePicker.DisplayDateStart = DateStartDatePicker.SelectedDate.Value.AddDays(1);
            if (DateEndDatePicker.SelectedDate != null)
            {
                TotalPriceTextBlock.Text =
                    ((DateEndDatePicker.SelectedDate - DateStartDatePicker.SelectedDate).Value.Days * _car.RentPrice).ToString();
            }
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void DateEndDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            TotalPriceTextBlock.Text =
                ((DateEndDatePicker.SelectedDate - DateStartDatePicker.SelectedDate).Value.Days * _car.RentPrice).ToString();
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async void RequestAddPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            switch (_car.CarStatusId)
            {
                case 1:
                    DateStartDatePicker.DisplayDateStart = DateTime.Today;
                    DateStartDatePicker.SelectedDate = DateTime.Today;
                    break;
                case 2:
                    Request request =
                        await DB.Context.Requests.LastAsync(
                            c => c.CarId == _car.CarId && (c.RequestStatusId == 2 || c.RequestStatusId == 6));
                    DateStartDatePicker.DisplayDateStart = request.EndDate;
                    DateStartDatePicker.SelectedDate = request.EndDate;
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