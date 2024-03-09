using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.UserControls.EmployeePages;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using WpfAnimatedGif;

namespace CarRent.UserControls;

public partial class CarViewControl : UserControl
{
    private List<Car>? _cars;
    private List<Brand> _brands;
    private List<Model> _models;
    private List<Class> _classes;

    public CarViewControl()
    {
        InitializeComponent();
    }

    private async void CarViewControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        await LoadData();
        BrandComboBox.ItemsSource = _brands;
        ModelComboBox.ItemsSource = _models;
        ClassComboBox.ItemsSource = _classes;
        BrandComboBox.SelectedIndex = 0;
        ModelComboBox.SelectedIndex = 0;
        ClassComboBox.SelectedIndex = 0;
    }

    private async Task LoadData()
    {
        _brands = new List<Brand> { new Brand { Name = "Любая" } };
        _classes = new List<Class> { new Class { Name = "Любой" } };
        ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
        _brands.AddRange(await DB.Context.Brands.ToListAsync());
        _classes.AddRange(await DB.Context.Classes.ToListAsync());

        ImageBehavior.SetAnimatedSource(LoadingImage, null);
    }

    private void OpenFilter_OnClick(object sender, RoutedEventArgs e) => Popup.IsOpen = !Popup.IsOpen;

    private void BrandComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
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

    private void ModelComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void ClassComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateData();

    private void UpdateData()
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

    private void CarListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        User user = ((App)App.Current).GetCurrentUser();
        if (user != null)
        {
            if (user.RoleId == 1)
            {
                NavigationService navigationService = NavigationService.GetNavigationService(this)!;
                navigationService!.Navigate(new CarEditControl(CarListView.SelectedItem as Car));
            }
        }
        else
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this)!;
            navigationService!.Navigate(new CarViewControl());
        }
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService navigationService = NavigationService.GetNavigationService(this);
        navigationService.Navigate(new CarEditControl());
    }
}