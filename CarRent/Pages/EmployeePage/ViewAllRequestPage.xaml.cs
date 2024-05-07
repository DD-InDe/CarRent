using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Aspose.Words;
using CarRent.Entities;
using CarRent.Entities.Models;
using CarRent.Pages.ClientPages;
using CarRent.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WpfAnimatedGif;

namespace CarRent.Pages.EmployeePage;

public partial class ViewAllRequestPage : Page
{
    private List<Request> _requests;
    private List<RequestStatus> _statusList;
    private List<User> _clients;

    public ViewAllRequestPage()
    {
        InitializeComponent();
        
        CreateDocButton.Visibility = App.GetCurrentUser().RoleId == 1 ? Visibility.Visible : Visibility.Collapsed;
    }

    private async void ViewAllRequestPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            if (RequestListView.ItemsSource == null)
            {
                await LoadData();
                StatusComboBox.ItemsSource = _statusList;
                ClientComboBox.ItemsSource = _clients;
                StatusComboBox.SelectedIndex = 0;
                ClientComboBox.SelectedIndex = 0;
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
            _statusList = new List<RequestStatus> { new RequestStatus { Name = "Все" } };
            _clients = new List<User> { new User { FirstName = "Все" } };
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            _statusList.AddRange(await DB.Context.RequestStatuses.ToListAsync());
            _clients.AddRange(await DB.Context.Users.Where(c => c.RoleId == 3).ToListAsync());

            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void OpenFilter_OnClick(object sender, RoutedEventArgs e) => Popup.IsOpen = !Popup.IsOpen;

    private void StatusComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void ClientComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateData();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateData();

    private async void UpdateData()
    {
        try
        {
            ImageBehavior.SetAnimatedSource(LoadingImage, (BitmapImage)FindResource("Loading"));
            User selectedClient = ClientComboBox.SelectedItem as User;
            RequestStatus selectedStatus = StatusComboBox.SelectedItem as RequestStatus;
            
            if (selectedClient == null || selectedStatus == null)
                return;

            string searchText = SearchTextBox.Text.ToLower();

            _requests = await DB.Context.Requests
                .Include(c => c.Car)
                .Include(c => c.Car.BrandModel)
                .Include(c => c.Car.BrandModel.Brand)
                .Include(c => c.Car.BrandModel.Model)
                .Include(c => c.Client)
                .Include(c => c.RequestStatus)
                .Where(c => (c.Client == selectedClient || selectedClient.FirstName == "Все") &&
                            (c.RequestStatus == selectedStatus || selectedStatus.Name == "Все") &&
                            (c.Client.FirstName.ToLower().Contains(searchText) ||
                             c.Client.LastName.ToLower().Contains(searchText) ||
                             c.Client.MiddleName.ToLower().Contains(searchText) ||
                             c.Car.BrandModel.Model.Name.ToLower().Contains(searchText) ||
                             c.Car.BrandModel.Brand.Name.ToLower().Contains(searchText) ||
                             c.Car.BrandModel.Class.Name.ToLower().Contains(searchText)))
                .ToListAsync();
            RequestListView.ItemsSource = _requests;

            ImageBehavior.SetAnimatedSource(LoadingImage, null);
        }
        catch (Exception exception)
        {
            CustomMessageBox messageBox = new CustomMessageBox(Icon.ErrorIcon, $"Произошла ошибка: {exception.Message}", Button.Ok);
            messageBox.ShowDialog();
        }
    }

    private void RequestListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        NavigationService.Navigate(new RequestInfoPage(RequestListView.SelectedItem as Request));
    }

    private void CreateDocButton_OnClick(object sender, RoutedEventArgs e)
    {
        Document document = new Document();
        DocumentBuilder builder = new DocumentBuilder(document);

        document.FirstSection.Body.Paragraphs[0].ParagraphFormat.Alignment = ParagraphAlignment.Center;

        string title = "Заявки на аренду авто";
        Aspose.Words.Font font = builder.Font;
        font.Size = 20;
        font.Bold = false;
        font.Color = Color.Black;
        font.Name = "Times New Roman";
        
        builder.Writeln(title);
        
        font = builder.Font;
        font.Size = 14;
        font.Color = Color.Black;
        font.Name = "Times New Roman";
        
        
        builder.StartTable();

        InsertText("Срок аренды");
        InsertText("Клиент");
        InsertText("Авто");
        builder.EndRow();

        foreach (var request in _requests)
        {
            string date = $"{request.StartDateOnly} - {request.EndDateOnly}";
            InsertText(date);
            
            string[] clientInfo = new[]
            {
                $"ФИО: {request.Client.FullName}",
                $"Телефон: {request.Client.Phone}",
            };
            InsertMultiText(clientInfo);
            
            string[] autoInfo = new[]
            {
                $"Марка: {request.Car.BrandModel.Brand.Name}",
                $"Модель: {request.Car.BrandModel.Model.Name}",
                $"Класс: {request.Car.BrandModel.Class.Name}",
                $"VIN: {request.Car.CarVin}",
            };
            InsertMultiText(autoInfo);

            builder.EndRow();
        }

        void InsertText(string text)
        {
            builder.InsertCell();
            builder.Writeln(text);
        }

        void InsertMultiText(string[] text)
        {
            builder.InsertCell();
            foreach (var s in text)
            {
                builder.Write(s);
            }
        }

        builder.EndTable();
        
        builder.Writeln($"Всего: {_requests.Count} заявок");
        string fileName = $"Заявки_аренды_{DateTime.Today.ToString("dd_MM_yy")}.docx";
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Title = "Сохранить документ",
            FileName = fileName
        };
        
        if (saveFileDialog.ShowDialog() == true)
            document.Save(saveFileDialog.FileName);
    }
}