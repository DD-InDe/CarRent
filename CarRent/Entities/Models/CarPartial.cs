namespace CarRent.Entities.Models;

public partial class Car
{
    public string Price => "Цена за сутки: " + RentPrice;
}