namespace CarRent.Entities.Models;

public partial class User
{
    public string FullName => $"{LastName} {FirstName} {MiddleName}";
}