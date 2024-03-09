using System.Windows;
using CarRent.Entities.Models;

namespace CarRent
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private User? CurrentUser { get; set; }

        public void SetCurrentUser(User user) => CurrentUser = user;

        public User? GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}