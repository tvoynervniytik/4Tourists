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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        public static List<Booking> booking = new List<Booking>();
        public static Booking bookingDel = new Booking();
        public static Booking bookingEdit = new Booking();
        public BookingPage()
        {
            InitializeComponent();
            booking = new List<Booking>(DBConnection.TouristsGo.Booking.ToList());
            BookingSlv.ItemsSource = booking;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBookingWindow addBookingWindow = new AddBookingWindow();
            addBookingWindow.Show();
        }

        public static void DeleteBooking(Booking booking)
        {

            DBConnection.TouristsGo.Booking.Remove(booking);
            DBConnection.TouristsGo.SaveChanges();


        }
        public static List<Booking> SourceStudentsList(Booking employee)
        {
            return new List<Booking>(DBConnection.TouristsGo.Booking.ToList());
        }
        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BookingSlv.SelectedItem != null)
            {
                DeleteBooking(BookingSlv.SelectedItem as Booking);
                BookingSlv.SelectedItem = null;
                BookingSlv.ItemsSource = SourceStudentsList(bookingDel);
            }
            else
            {
                MessageBox.Show("Выберите работника для удаления");
            }
        }


        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            booking = new List<Booking>(DBConnection.TouristsGo.Booking.ToList());
            BookingSlv.ItemsSource = booking;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            if (BookingSlv.SelectedItem != null)
            {
                bookingEdit = BookingSlv.SelectedItem as Booking;
                EditBookingWindow editBookingWindow = new EditBookingWindow(bookingEdit);
                editBookingWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите работника для редактирования");
            }
        }
    }
}
