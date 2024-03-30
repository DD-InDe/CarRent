namespace CarRent.Entities.Models;

public partial class DriverLicense
{
    public string StartDateOnly => DataOfIssue.Value.ToString("d");
    public string EndDateOnly => ExpirationData.Value.ToString("d");
}