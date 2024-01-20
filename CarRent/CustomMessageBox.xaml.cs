using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CarRent;

public partial class CustomMessageBox : Window
{
    public string Result { get; private set; }
    
    public CustomMessageBox(string message, string buttons, string title = "Сообщение")
    {
        InitializeComponent();

        IconImage.Source = new BitmapImage(new Uri(@"C:\\Users\\deer\\Курсовая\\CarRent\\CarRent\\Resources\\Exit.png"));
        
        Title = title;
        MessageTextBlock.Text = message;

        switch (buttons)
        {
            case "YesNo":   
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
                break;
            case "Ok":
                OkButton.Visibility = Visibility.Visible;
                break;
        }
    }
    
    private void YesButton_OnClick(object sender, RoutedEventArgs e)
    {
        Result = "Yes";
        Close();
    }

    private void NoButton_OnClick(object sender, RoutedEventArgs e)
    {
        Result = "No";
        Close();
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        Result = "Ok";
        Close();
    }
}