using System.Windows;
using System.Windows.Media.Imaging;

namespace CarRent.Windows;

public partial class CustomMessageBox : Window
{
    public string? Result { get; private set; }
    
    public CustomMessageBox(Icon icon, string message, Button button, string title = "Сообщение")
    {
        InitializeComponent();

        Title = title;
        MessageTextBlock.Text = message;

        switch (button.ToString())
        {
            case "YesNo":   
                YesButton.Visibility = Visibility.Visible;
                NoButton.Visibility = Visibility.Visible;
                break;
            case "Ok":
                OkButton.Visibility = Visibility.Visible;
                break;
        }

        IconImage.Source = (BitmapImage)FindResource(icon.ToString());
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