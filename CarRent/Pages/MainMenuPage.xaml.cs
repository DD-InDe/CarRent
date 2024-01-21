using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using CarRent.Models;

namespace CarRent.Pages;

public partial class MainMenuPage : Page
{
    public MainMenuPage(User user)
    {
        InitializeComponent();
        // PageFrame.Navigate(new AuthPage());
        PageFrame.Navigate(new RegPage());
    }

    private void MenuButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var d = sender;
    }

    private void PageFrame_OnNavigated(object sender, NavigationEventArgs e)
    {
        
    }
}
