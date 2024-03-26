using System;
using System.Drawing;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CarRent.Entities.Models;
using CarRent.Pages;
using CarRent.Pages.ClientPages;
using CarRent.Pages.EmployeePage;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace CarRent.Windows;

public partial class MainWindow : Window
{
    private User _user;

    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new CatalogAutoPage());

        AllOrdersButton.Visibility = Visibility.Collapsed;
        UsersButton.Visibility = Visibility.Collapsed;
        MyOrdersButton.Visibility = Visibility.Collapsed;
    }

    public MainWindow(User user)
    {
        InitializeComponent();
        MainFrame.Navigate(new CatalogAutoPage());
        _user = user;

        switch (user.RoleId)
        {
            case 1:
                MyOrdersButton.Visibility = Visibility.Collapsed;
                break;
            case 2:
                MyOrdersButton.Visibility = Visibility.Collapsed;
                UsersButton.Visibility = Visibility.Collapsed;
                break;
            case 3:
                AllOrdersButton.Visibility = Visibility.Collapsed;
                UsersButton.Visibility = Visibility.Collapsed;
                break;
        }
    }

    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DoubleAnimation gridAnimation = new DoubleAnimation();
        gridAnimation.From = MenuGrid.ActualWidth;
        if (MenuGrid.ActualWidth == 220)
            gridAnimation.To = 50;
        else
            gridAnimation.To = 220;
        gridAnimation.Duration = TimeSpan.FromMilliseconds(300);
        MenuGrid.BeginAnimation(Grid.WidthProperty, gridAnimation);
        gridAnimation.AccelerationRatio = 1;
    }

    private void ChangeBackground(object sender)
    {
        foreach (System.Windows.Controls.Button button in ButtonPanel.Children.OfType<System.Windows.Controls.Button>())
            ((StackPanel)button.Content).Children.OfType<Rectangle>().Last().Fill = Brushes.Transparent;
        ((StackPanel)((System.Windows.Controls.Button)sender).Content).Children.OfType<Rectangle>().Last().Fill = Brushes.White;
    }

    private void CarCatalogButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
        if (_user != null)
            MainFrame.Navigate(new CatalogAutoPage(_user));
        else
            MainFrame.Navigate(new CatalogAutoPage());
    }

    private void MyOrdersButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
        MainFrame.Navigate(new ViewMyRequestPage(_user));
    }

    private void CompanyInfoButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
        MainFrame.Navigate(new InfoPage());
    }

    private void PersonalAreaButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
    }

    private void ExitButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
        AccessWindow accessWindow = new AccessWindow();
        ((App)App.Current).SetCurrentUser(null);
        Application.Current.MainWindow = accessWindow;
        accessWindow.Show();
        Close();
    }

    private void Element_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        object val = (Page)MainFrame.Content;
        if (val != null)
            ((Page)MainFrame.Content).Width = ActualWidth - MenuGrid.ActualWidth;
    }

    private void AllOrdersButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
        MainFrame.Navigate(new ViewAllRequestPage());
    }

    private void UsersButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeBackground(sender);
        MainFrame.Navigate(new ViewUserPage());
    }
}