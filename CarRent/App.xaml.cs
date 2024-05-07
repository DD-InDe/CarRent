using System.Windows;
using CarRent.Entities.Models;

namespace CarRent
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static User? CurrentUser { get; set; }

        public void SetCurrentUser(User user) => CurrentUser = user;

        public static User? GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}