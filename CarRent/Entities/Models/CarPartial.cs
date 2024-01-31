namespace CarRent.Models;

public partial class Car
{
    private string Price => "Цена за сутки: " + RentPrice;
}