using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace CarRent.UserControls.EmployeePages;

public partial class CarEditPage : UserControl
{
    public CarEditPage()
    {
        InitializeComponent();
    }

    private void CarPhotoImage_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "png;jpg;jpeg |*.png, *.jpg, *jpeg"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            CarPhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            byte[] photo = File.ReadAllBytes(openFileDialog.FileName);
        }
    }
}