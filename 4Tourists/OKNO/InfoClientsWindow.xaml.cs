using _4Tourists.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
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
    /// Логика взаимодействия для InfoClientsWindow.xaml
    /// </summary>
    public partial class InfoClientsWindow : Window
    {
        public static List<Clients> clients {  get; set; }
        Clients contextClients;
        public static Clients cli { get; set; }


        private void InitializeDataInPage()
        {
            clients = new List<Clients>(DBConnection.TouristsGo.Clients.ToList());
        }
        public InfoClientsWindow(Clients client)
        {
            InitializeComponent();
            contextClients = client;
            cli = client;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var val = new ValidationContext(contextClients);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateObject(contextClients, val, results, true))
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
            if (contextClients.Id == 0)
                DBConnection.TouristsGo.Clients.Add(contextClients);
            DBConnection.TouristsGo.SaveChanges();
            this.Close();
        }
    }
}
