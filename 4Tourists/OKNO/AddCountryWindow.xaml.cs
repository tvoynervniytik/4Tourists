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
using System.Windows.Shapes;

namespace _4Tourists.OKNO
{
    /// <summary>
    /// Логика взаимодействия для AddCountryWindow.xaml
    /// </summary>
    public partial class AddCountryWindow : Window
    {
        public static List<City> cities {  get; set; }
        public static List<Country> countries { get; set; }
        public AddCountryWindow()
        {
            InitializeComponent();
            cities = new List<City>(DBConnection.TouristsGo.City.ToList());
            countries = new List<Country>(DBConnection.TouristsGo.Country.ToList());
            this.DataContext = this;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Country country = new Country();
            country.Name = CountryTB.Text.Trim();

            DBConnection.TouristsGo.Country.Add(country);
            DBConnection.TouristsGo.SaveChanges();

            City city = new City();
            city.Name = CityTB.Text.Trim();
            city.IdCountry = country.Id;

            DBConnection.TouristsGo.City.Add(city);
            DBConnection.TouristsGo.SaveChanges();

            this.Close();
        }
    }
}
