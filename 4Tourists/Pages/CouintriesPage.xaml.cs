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
    /// Логика взаимодействия для CouintriesPage.xaml
    /// </summary>
    public partial class CouintriesPage : Page
    {
        public static List<Country> countries { get; set; }
        public CouintriesPage()
        {
            InitializeComponent();
            countries = new List<Country>(DBConnection.TouristsGo.Country.ToList());
            this.DataContext = this;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountriesSlv.SelectedItem is Country country)
            {
                DBConnection.TouristsGo.Country.Remove(country);
                DBConnection.TouristsGo.SaveChanges();
                CountriesSlv.ItemsSource = DBConnection.TouristsGo.Country.ToList();
            }
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
