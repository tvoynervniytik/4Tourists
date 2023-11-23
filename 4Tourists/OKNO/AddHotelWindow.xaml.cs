using _4Tourists.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для AddHotelWindow.xaml
    /// </summary>
    public partial class AddHotelWindow : Window
    {
        public static List<Hotel> hotels = new List<Hotel>();
        public static Hotel hot = new Hotel();
        public AddHotelWindow()
        {
            InitializeComponent();
            hotels = new List<Hotel>(DBConnection.TouristsGo.Hotel.ToList());
            this.DataContext = this;
            CityCB.ItemsSource = DBConnection.TouristsGo.City.ToList();
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

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var awds = "Название: " + NameTB.Text
                + " " + "Количество звезд: " + ZvezdaTB.Text;


            if (MessageBox.Show(awds, "Проверьте корректность введенных данных", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {

                hot.Name = NameTB.Text.Trim();
                hot.Stars = int.Parse(ZvezdaTB.Text.Trim());
                var a = CityCB.SelectedItem as City;
                hot.IdCity = a.Id;
                DBConnection.TouristsGo.Hotel.Add(hot);
                DBConnection.TouristsGo.SaveChanges();
                this.Close();

            }
        }
    }
}
