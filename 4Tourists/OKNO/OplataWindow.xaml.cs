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
    /// Логика взаимодействия для OplataWindow.xaml
    /// </summary>
    public partial class OplataWindow : Window
    {
        public static List<Promocode> promocodes { get; set; }
        public static Booking booking1 { get; set; }
        Booking contextBooking;
        public OplataWindow(Booking booking)
        {
            InitializeComponent();
            contextBooking = booking;
            booking1 = booking;
            InitializeDataInPage();
            this.DataContext = this;
        }
        private void InitializeDataInPage()
        {
            promocodes = new List<Promocode>(DBConnection.TouristsGo.Promocode.ToList());
            PromCB.ItemsSource = DBConnection.TouristsGo.Promocode.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void PromCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var COST = PromCB.SelectedItem as Promocode;
            double skidka = (double)COST.Procent;
            double costtour = (double)contextBooking.Cost;
            double rachet = (skidka / 100) * costtour;
            CostTB.Text = (costtour - rachet).ToString();
        }
    }
}
