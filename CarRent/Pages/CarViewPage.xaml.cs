using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages;

public partial class CarViewPage : Page
{
    private ObservableCollection<Car> Cars;
    
    public CarViewPage()
    {
        InitializeComponent();
    }

    private async void CarViewPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
        var cars = await DB._context.Cars
            .Include(c => c.BrendModel)
            .Include(c => c.BrendModel.Brend)
            .Include(c => c.BrendModel.Class)
            .Include(c => c.BrendModel.Model)
            .Include(c => c.CarStatus)
            .ToListAsync();
        Cars = new ObservableCollection<Car>(cars);
        ImageBehavior.SetAnimatedSource(LoadingImage, null);
        CarListView.ItemsSource = Cars;
    }

    private void CarViewPage_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        // MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        // double freeWidth = mainWindow.ActualWidth - mainWindow.freeWidth;
        // if (freeWidth < 800)
        //     UniformGridPage.Columns = 2;
        // else if(freeWidth < 1000)
        //     UniformGridPage.Columns = 3;
        // else if(freeWidth < 1200)
        //     UniformGridPage.Columns = 4;
        // else if(freeWidth < 1400)
        //     UniformGridPage.Columns = 5;
    }
}