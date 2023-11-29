using _4Tourists.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4Tourists.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Page
    {

        public static Employee loggedUser;
        public AdminHomePage()
        {
            InitializeComponent();
            var FIO = DBConnection.loginedUser.Surname +' '+ DBConnection.loginedUser.Name;
            loggedUser = DBConnection.loginedUser;
            UserNameTB.Text = FIO;


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void toursBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ToursPage());
        }

        private void clientsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }

        private void hotelsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HotelsPage());
        }

        private void countriesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CouintriesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PromocodesPage());
        }

        private void bookingBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookingPage());
        }
    }
}
