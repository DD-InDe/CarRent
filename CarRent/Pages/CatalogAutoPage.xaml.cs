using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Pages.ClientPages;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.Pages;

public partial class CatalogAutoPage : Page
{
    private List<Car>? _cars;
    private List<Brand> _brands;
    private List<Model> _models;
    private List<Class> _classes;

    public CatalogAutoPage()
    {
        InitializeComponent();
    }

    private async void CatalogAutoPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            if (CarListView.ItemsSource == null)
            {
                await LoadData();
                BrandComboBox.ItemsSource = _brands;
                ModelComboBox.ItemsSource = _models;
                ClassComboBox.ItemsSource = _classes;
                BrandComboBox.SelectedIndex = 0;
                ModelComboBox.SelectedIndex = 0;
                ClassComboBox.SelectedIndex = 0;
            }
            else
                UpdateData();
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private async Task LoadData()
    {
        try
        {
            _brands = new List<Brand> { new Brand { Name = "Любая" } };
            _classes = new List<Class> { new Class { Name = "Любой" } };
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            _brands.AddRange(await DB.Context.Brands.ToListAsync());
            _classes.AddRange(await DB.Context.Classes.ToListAsync());

            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void OpenFilter_OnClick(object sender, RoutedEventArgs e) => Popup.IsOpen = !Popup.IsOpen;

    private void BrandComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            _models = new List<Model> { new Model { Name = "Любая" } };
            Brand currentBrand = BrandComboBox.SelectedItem as Brand;

            _models.AddRange(DB.Context.BrandModels
                .Include(c => c.Brand)
                .Include(c => c.Model)
                .Where(c => c.Brand == currentBrand || currentBrand.BrandId == 0)
                .Select(c => c.Model)
                .ToList());

            ModelComboBox.ItemsSource = _models;
            ModelComboBox.SelectedIndex = 0;
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void ModelComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void ClassComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateData();

    private void UpdateData()
    {
        try
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            Brand selectedBrand = BrandComboBox.SelectedItem as Brand;
            Model selectedModel = ModelComboBox.SelectedItem as Model;
            Class selectedClass = ClassComboBox.SelectedItem as Class;

            if (selectedBrand == null || selectedModel == null || selectedClass == null)
                return;

            string searchText = SearchTextBox.Text.ToLower();

            _cars = DB.Context.Cars
                .Include(c => c.BrandModel)
                .Include(c => c.BrandModel.Brand)
                .Include(c => c.BrandModel.Model)
                .Include(c => c.BrandModel.Class)
                .Include(c => c.CarStatus)
                .Where(c => (c.BrandModel.Brand == selectedBrand || selectedBrand.Name == "Любая") &&
                            (c.BrandModel.Model == selectedModel || selectedModel.Name == "Любая") &&
                            (c.BrandModel.Class == selectedClass || selectedClass.Name == "Любой") &&
                            (c.BrandModel.Brand.Name.ToLower().Contains(searchText) ||
                             c.BrandModel.Model.Name.ToLower().Contains(searchText) ||
                             c.BrandModel.Class.Name.ToLower().Contains(searchText)))
                .ToList();
            CarListView.ItemsSource = _cars;

            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void CarListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        try
        {
            User user = ((App)App.Current).GetCurrentUser();
            if (user != null)
            {
                switch (user.RoleId)
                {
                    case 1:
                        NavigationService.Navigate(new CarEditPage(CarListView.SelectedItem as Car));
                        break;
                    case 3:
                        NavigationService.Navigate(new CarInfoPage(CarListView.SelectedItem as Car));
                        break;
                }
            }
            else
                NavigationService.Navigate(new CarInfoPage(CarListView.SelectedItem as Car));
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new CarEditPage());
    }
}