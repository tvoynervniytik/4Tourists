using _4Tourists.DB;
using ControlzEx.Standard;
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


        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity = CityCB.SelectedItem as City;
            if (selectedCity != null)
            {
                HotelCB.ItemsSource = DBConnection.TouristsGo.Hotel.Where(x => x.Id == selectedCity.Id).ToList();
            }
        }
        

        private void CostBT_Click(object sender, RoutedEventArgs e)
        {
            var costtour = int.Parse(CostTB.Text.Trim());
            var costnutriotion = PitanieCB.SelectedItem as Nutrition;
            var nutriotion = costnutriotion.Price;
            CostTourTB.Text = (costtour + nutriotion).ToString();
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

            tour.Name = NameTB.Text.Trim();
            var a = TypeTourCB.SelectedItem as TypeTour;
            tour.IdTypetour = a.Id;
            tour.Cost = decimal.Parse(CostTB.Text.Trim());
            var b = PitanieCB.SelectedItem as Nutrition;
            tour.IdNutrition = b.Id;
            var c = CountryCB.SelectedItem as Country;
            tour.IdCountry = c.Id;
            var d = CityCB.SelectedItem as City;
            tour.IdCity = d.Id;
            var f = HotelCB.SelectedItem as Hotel;
            tour.IdHotel = f.Id;

            

            DBConnection.TouristsGo.Tours.Add(tour);
            DBConnection.TouristsGo.SaveChanges();
            this.Close();
        }
    }
        
}
