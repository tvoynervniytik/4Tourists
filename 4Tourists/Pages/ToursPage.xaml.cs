using _4Tourists.DB;
using _4Tourists.OKNO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            if (ToursSlv.SelectedItem is Tours tours)
            {
                DBConnection.TouristsGo.Tours.Remove(tours);
                DBConnection.TouristsGo.SaveChanges();
                ToursSlv.ItemsSource = DBConnection.TouristsGo.Tours.ToList();
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTourWindow addTourWindow = new AddTourWindow();
            addTourWindow.Show();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
