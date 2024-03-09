namespace CarRent.Entities.Models;

public partial class Request
{
    public string StartDateOnly => StartDate.Value.ToString("d");
    public string EndDateOnly => EndDate.Value.ToString("d");
}