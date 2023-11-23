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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public static List<Tours> tours { get; set; }
        public static List<Nutrition> nutritions { get; set; }
        public static List<City> cities { get; set; }
        public static List<Country> countries { get; set; }
        public static List<Hotel> hotels { get; set; }
        public static List<TypeTour> types { get; set; }
        public ToursPage()
        {
            InitializeComponent();
            tours = new List<Tours>(DBConnection.TouristsGo.Tours.ToList());
            nutritions = new List<Nutrition>(DBConnection.TouristsGo.Nutrition.ToList());
            cities = new List<City>(DBConnection.TouristsGo.City.ToList());
            countries = new List<Country>(DBConnection.TouristsGo.Country.ToList());
            hotels = new List<Hotel>(DBConnection.TouristsGo.Hotel.ToList());
            types = new List<TypeTour>(DBConnection.TouristsGo.TypeTour.ToList());
            this.DataContext = this;
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
