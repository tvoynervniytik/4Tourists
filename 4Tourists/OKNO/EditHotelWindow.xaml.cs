using _4Tourists.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4Tourists.OKNO
{
    /// <summary>
    /// Логика взаимодействия для EditHotelWindow.xaml
    /// </summary>
    public partial class EditHotelWindow : Window
    {
        public static List<Hotel> hotels { get; set; }
        Hotel contexthotel;
        public static Hotel hot {  get; set; }

        private void InitializeDataInPage()
        {
            hotels = new List<Hotel>(DBConnection.TouristsGo.Hotel.ToList());
            CityCB.ItemsSource = DBConnection.TouristsGo.City.ToList();
            
        }
        
        public EditHotelWindow(Hotel hotel)
        {
            InitializeComponent();
            contexthotel = hotel;
            hot = hotel;
            
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var validationContext = new ValidationContext(contexthotel);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(contexthotel, validationContext, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result.ErrorMessage}\n";
                }
            }
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            if (contexthotel.Id == 0)
            {
                DBConnection.TouristsGo.Hotel.Add(contexthotel);
                DBConnection.TouristsGo.SaveChanges();
            }
                
            this.Close();
        }

        private void AddPhotoBT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                hot.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PhotoIM.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
