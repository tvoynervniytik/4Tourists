using _4Tourists.DB;
using MahApps.Metro.Controls;
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
    /// Логика взаимодействия для EditBookingWindow.xaml
    /// </summary>
    public partial class EditBookingWindow : Window
    {
        public static List<Booking> booking = new List<Booking>();

        public static Booking booking1 = new Booking();
        public static Booking bookingEdit= new Booking();
        Booking contextBooking;
        public static Booking bookinges { get; set; }
        private void InitializeDataInPage()
        {
            booking = new List<Booking>(DBConnection.TouristsGo.Booking.ToList());
            EmployeeCb.ItemsSource = DBConnection.TouristsGo.Employee.ToList();
            ClientCb.ItemsSource = DBConnection.TouristsGo.Clients.ToList();
            ToursCb.ItemsSource = DBConnection.TouristsGo.Tours.ToList();
            DepartureDp.Text = DBConnection.TouristsGo.Booking.ToList().ToString();
            ArrivalDp.Text = DBConnection.TouristsGo.Booking.ToList().ToString();
            BookingDp.Text = DBConnection.TouristsGo.Booking.ToList().ToString();
            QuantityTb.Text = DBConnection.TouristsGo.Booking.ToList().ToString();
            CostTb.Text = DBConnection.TouristsGo.Booking.ToList().ToString();


        }
        public EditBookingWindow(Booking bookingEdit)
        {
            InitializeComponent();
            booking1 = bookingEdit;
            contextBooking = bookingEdit;
            bookinges = bookingEdit;
            InitializeDataInPage();
            this.DataContext = this;

            DateTime dateTime = Convert.ToDateTime(DepartureDp.SelectedDate);
            DateTime dateTime1 = Convert.ToDateTime(ArrivalDp.SelectedDate);
            TimeSpan t = dateTime1 - dateTime;
            CountDayDp.Text = t.TotalDays.ToString();
            


        }

        private void EditBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            bookingEdit = booking1;
            if (EmployeeCb.Text == "" || ClientCb.Text == "" || ToursCb.Text == "" || DepartureDp.Text == "" || ArrivalDp.Text == "" || BookingDp.Text == "" || QuantityTb.Text == "")
            {
                MessageBox.Show("Запоолниет все поля!!!");

            }
            else
            {
                bookingEdit.IdEmployee = (EmployeeCb.SelectedItem as Employee).Id;
                bookingEdit.IdClient = (ClientCb.SelectedItem as Clients).Id;
                bookingEdit.IdTour = (ToursCb.SelectedItem as Tours).Id;
                bookingEdit.DateDeparture = Convert.ToDateTime(DepartureDp.Text);
                bookingEdit.DateArrival = Convert.ToDateTime(ArrivalDp.Text);
                bookingEdit.DateBooking = Convert.ToDateTime(BookingDp.Text);
                bookingEdit.Quantity = Convert.ToInt32(QuantityTb.Text);

                bookingEdit.Cost = bookingEdit.Tours.Cost * bookingEdit.Quantity;
                int count = Convert.ToInt32(QuantityTb.Text);
                int count1 = count - 2;
                if (count > 1 && contextBooking.Quantity != count)
                {
                    count -= 1;
                    count1 += 1;
                    AdditionalClientWindow additionalClientWindow = new AdditionalClientWindow(count1, count);
                    additionalClientWindow.Show();
                }
                DBConnection.TouristsGo.SaveChanges();
                Close();
            }

        }


        

        private void ToursCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var a = ToursCb.SelectedItem as Tours;
            var selectedTour = DBConnection.TouristsGo.Tours.FirstOrDefault(i => i.Id == a.Id);
            if (selectedTour != null)
            {

                CostTb.Text = (selectedTour.Cost * bookingEdit.Quantity).ToString();
            }
           
        }
        private void QuantityTb_TextChanged(object sender, TextChangedEventArgs e)
        {    
            bookingEdit = booking1;
            CostTb.Text = (bookingEdit.Tours.Cost * bookingEdit.Quantity).ToString();
        }


        private void DepartureDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(DepartureDp.SelectedDate);
            DateTime dateTime1 = Convert.ToDateTime(ArrivalDp.SelectedDate);
            TimeSpan t = dateTime1 - dateTime;
            CountDayDp.Text = t.TotalDays.ToString();
            ArrivalDp.DisplayDateStart = dateTime;
        }

        private void ArrivalDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(DepartureDp.SelectedDate);
            DateTime dateTime1 = Convert.ToDateTime(ArrivalDp.SelectedDate);
            TimeSpan t = dateTime1 - dateTime;
            CountDayDp.Text = t.TotalDays.ToString();
        }

    }
}
