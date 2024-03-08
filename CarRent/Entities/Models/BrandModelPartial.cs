namespace CarRent.Entities.Models;

public partial class BrandModel
{
    public string NamesOnly => $"{Brand.Name} {Model.Name}";
}