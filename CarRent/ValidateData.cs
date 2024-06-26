﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using CarRent.Entities;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using Xceed.Wpf.Toolkit;

namespace CarRent;

public static class ValidateData
{
    private static CustomMessageBox _messageBox;

    public static bool CheckFields(List<object> fields)
    {
        try
        {
            bool isFull = true;

            foreach (var item in fields)
            {
                if (isFull)
                {
                    string[] senderType = item.GetType().ToString().Split(".");
                    switch (senderType[senderType.Length - 1])
                    {
                        case "TextBox":
                            TextBox textBox = (item as TextBox)!;
                            if (String.IsNullOrWhiteSpace(textBox.Text))
                                isFull = false;
                            break;
                        case "MaskedTextBox":
                            MaskedTextBox maskedTextBox = (item as MaskedTextBox)!;
                            if (!maskedTextBox.IsMaskCompleted)
                                isFull = false;
                            break;
                        case "PasswordBox":
                            PasswordBox passwordBox = (item as PasswordBox)!;
                            if (String.IsNullOrWhiteSpace(passwordBox.Password))
                                isFull = false;
                            break;
                        case "DatePicker":
                            DatePicker datePicker = (item as DatePicker)!;
                            if (datePicker.SelectedDate == null)
                                isFull = false;
                            break;
                        case "ComboBox":
                            ComboBox comboBox = (item as ComboBox)!;
                            if (comboBox.SelectedItem == null)
                                isFull = false;
                            break;
                    }
                }
            }

            if (isFull)
                return true;
            _messageBox = new CustomMessageBox(Icon.WarningIcon, "Пожалуйста, заполните все поля, помеченные *!", Button.Ok);
            _messageBox.ShowDialog();
            return false;
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }

        return false;
    }

    public static void HighlightingFields(object sender)
    {
        try
        {
            string[] senderType = sender.GetType().ToString().Split(".");
            switch (senderType[senderType.Length - 1])
            {
                case "TextBox":
                    TextBox textBox = (sender as TextBox)!;
                    if (String.IsNullOrWhiteSpace(textBox.Text))
                        textBox.BorderBrush = Brushes.OrangeRed;
                    else
                        textBox.BorderBrush = Brushes.DarkGray;
                    break;
                case "MaskedTextBox":
                    MaskedTextBox maskedTextBox = (sender as MaskedTextBox)!;
                    if (!maskedTextBox.IsMaskCompleted)
                        maskedTextBox.BorderBrush = Brushes.OrangeRed;
                    else
                        maskedTextBox.BorderBrush = Brushes.DarkGray;
                    break;
                case "PasswordBox":
                    PasswordBox passwordBox = (sender as PasswordBox)!;
                    if (String.IsNullOrWhiteSpace(passwordBox.Password))
                        passwordBox.BorderBrush = Brushes.OrangeRed;
                    else
                        passwordBox.BorderBrush = Brushes.DarkGray;
                    break;
                case "DatePicker":
                    DatePicker datePicker = (sender as DatePicker)!;
                    if (datePicker.SelectedDate == null)
                        datePicker.BorderBrush = Brushes.OrangeRed;
                    else
                        datePicker.BorderBrush = Brushes.DarkGray;
                    break;
                case "ComboBox":
                    ComboBox comboBox = (sender as ComboBox)!;
                    if (comboBox.SelectedItem == null)
                        comboBox.BorderBrush = Brushes.OrangeRed;
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

    public static async Task<bool> CheckLogin(string login)
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

    public static bool CheckEmail(string email)
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
}