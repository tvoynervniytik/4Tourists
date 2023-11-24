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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public static List<Clients> clients { get; set; }
        public ClientsPage()
        {
            InitializeComponent();
            clients = new List<Clients>(DBConnection.TouristsGo.Clients.ToList());
            this.DataContext = this;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsSlv.SelectedItem is Clients client)
            {
                DBConnection.TouristsGo.Clients.Remove(client);
                DBConnection.TouristsGo.SaveChanges();
                ClientsSlv.ItemsSource = DBConnection.TouristsGo.Clients.ToList();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsSlv.SelectedItem is Clients client)
            {
                InfoClientsWindow infoClientsWindow = new InfoClientsWindow(client);

                infoClientsWindow.Show();
            }

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            //ClientsSlv.ItemsSource = DBConnection.TouristsGo.Clients.ToList();
        }

        private void ClientsSlv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (ClientsSlv.SelectedItem is Clients client)
            //{
            //    InfoClientsWindow infoClientsWindow = new InfoClientsWindow(client);

            //    infoClientsWindow.Show();
            //}
        }
    }
}
