using _4Tourists.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddTourWindow.xaml
    /// </summary>
    public partial class AddTourWindow : Window
    {
        public static List<Tours> tours = new List<Tours>();
        public static Tours tour = new Tours();

        public AddTourWindow()
        {
            InitializeComponent();
            tours = new List<Tours>(DBConnection.TouristsGo.Tours.ToList());
            TypeTourCB.ItemsSource = DBConnection.TouristsGo.TypeTour.ToList();
            PitanieCB.ItemsSource = DBConnection.TouristsGo.Nutrition.ToList();
            CountryCB.ItemsSource = DBConnection.TouristsGo.Country.ToList();
            this.DataContext = this;
        }

        private void AddPhotoBT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                tour.Foto = File.ReadAllBytes(openFileDialog.FileName);
                PhotoIM.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void CountryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCountry = CountryCB.SelectedItem as Country;
            if (selectedCountry != null)
            {
                CityCB.ItemsSource = DBConnection.TouristsGo.City.Where(x => x.IdCountry == selectedCountry.Id).ToList();
            }

        }

        private void PitanieCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedPitanie = PitanieCB.ItemsSource as Nutrition;

            //if(selectedPitanie != null)
            //{
            //    CostTB.Text = PitanieCB.Text.ToString();
            //}
        }

        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity = CityCB.SelectedItem as City;
            if (selectedCity != null)
            {
                HotelCB.ItemsSource = DBConnection.TouristsGo.Hotel.Where(x => x.Id == selectedCity.Id).ToList();
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CostBT_Click(object sender, RoutedEventArgs e)
        {
            var costtour = int.Parse(CostTB.Text.Trim());
            var costnutriotion = PitanieCB.SelectedItem as Nutrition;
            var nutriotion = costnutriotion.Price;
            CostTourTB.Text = (costtour + nutriotion).ToString();
        }
    }
        
}
