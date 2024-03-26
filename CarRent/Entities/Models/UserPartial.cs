using System.Windows.Media;

namespace CarRent.Entities.Models;

public partial class User
{
    public string FullName => $"{LastName} {FirstName} {MiddleName}";
    
    public SolidColorBrush RoleColor
    {
        get
        {
            switch (RoleId)
            {
                case 1:
                    return Brushes.Yellow;
                case 2:
                    return Brushes.CornflowerBlue;
                default:
                    return Brushes.DarkGray;
            }
        }
    }
}