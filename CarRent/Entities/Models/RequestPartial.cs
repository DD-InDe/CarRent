using System.Windows.Media;

namespace CarRent.Entities.Models;

public partial class Request
{
    public string StartDateOnly => StartDate.Value.ToString("d");
    public string EndDateOnly => EndDate.Value.ToString("d");

    public SolidColorBrush RequestColor
    {
        get
        {
            switch (RequestStatusId)
            {
                case 1:
                    return Brushes.Yellow;
                case 2:
                    return Brushes.Green;
                case 3:
                    return Brushes.Red;
                case 6:
                    return Brushes.CornflowerBlue;
                default:
                    return Brushes.DarkGray;
            }
        }
    }
}