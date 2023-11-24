using _4Tourists.DB;
using _4Tourists.OKNO;
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
    /// Логика взаимодействия для CouintriesPage.xaml
    /// </summary>
    public partial class CouintriesPage : Page
    {
        public static List<City> cities { get; set; }
        public CouintriesPage()
        {
            InitializeComponent();
            cities = new List<City>(DBConnection.TouristsGo.City.ToList());
            this.DataContext = this;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCountryWindow addCountryWindow = new AddCountryWindow();

            addCountryWindow.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountriesSlv.SelectedItem is City city)
            {
                DBConnection.TouristsGo.City.Remove(city);
                DBConnection.TouristsGo.SaveChanges();
                CountriesSlv.ItemsSource = DBConnection.TouristsGo.City.ToList();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var city = CountriesSlv.SelectedItem as City;
            
                InfoCountryWindow infoCountryWindow = new InfoCountryWindow(city);

                infoCountryWindow.Show();

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            CountriesSlv.ItemsSource = DBConnection.TouristsGo.City.ToList();
        }
    }
}
