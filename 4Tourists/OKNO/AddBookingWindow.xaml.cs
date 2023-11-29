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
    /// Логика взаимодействия для AddBookingWindow.xaml
    /// </summary>
    public partial class AddBookingWindow : Window
    {
        public static List<Employee> employee = new List<Employee>();
        public static DB.Booking Booking = new DB.Booking();
        public static List<Tours> tours = new List<Tours>();
        public static DB.Tours Tours = new DB.Tours();
        public static List<Clients> clients = new List<Clients>();

        public AddBookingWindow()
        {
            InitializeComponent();
            employee = new List<Employee>(DBConnection.TouristsGo.Employee.ToList());
            tours = new List<Tours>(DBConnection.TouristsGo.Tours.ToList());
            clients = new List<Clients>(DBConnection.TouristsGo.Clients.ToList());
            EmployeeCb.ItemsSource = employee;
            EmployeeCb.DisplayMemberPath = "Name";
            ToursCb.ItemsSource = tours;
            ToursCb.DisplayMemberPath = "Name";
            ClientCb.ItemsSource = clients;
            ClientCb.DisplayMemberPath = "Name";



        }



        private void AddBookingBtn_Click(object sender, RoutedEventArgs e)
        {

            if (EmployeeCb.Text == "" || ToursCb.Text == "" || ClientCb.Text == "" || DepartureDp.Text == "" || ArrivalDp.Text == "" || BookingDp.Text == "" || QuantityTb.Text == "")
            {
                MessageBox.Show("Заполните все данные!!!");
            }
            else
            {
                Booking.IdEmployee = (EmployeeCb.SelectedItem as Employee).Id;
                Booking.IdTour = (ToursCb.SelectedItem as Tours).Id;
                Booking.IdClient = (ClientCb.SelectedItem as Clients).Id;
                Booking.DateDeparture = Convert.ToDateTime(DepartureDp.Text);
                Booking.DateArrival = Convert.ToDateTime(ArrivalDp.Text);
                Booking.DateBooking = Convert.ToDateTime(BookingDp.Text);
                Booking.Quantity = Convert.ToInt32(QuantityTb.Text);

                int count = Convert.ToInt32(QuantityTb.Text);
                int count1 = count - 2;
                if (count > 1)
                {
                    count -= 1;
                    count1 += 1;
                    AdditionalClientWindow additionalClientWindow = new AdditionalClientWindow(count1, count);
                    additionalClientWindow.Show();
                }
                DBConnection.TouristsGo.Booking.Add(Booking);
                DBConnection.TouristsGo.SaveChanges();
                Close();
            }


        }
    }
}
