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
    /// Логика взаимодействия для AddClientsWindow.xaml
    /// </summary>
    public partial class AddClientsWindow : Window
    {
        public static DB.Clients clients = new DB.Clients();
        
        public AddClientsWindow()
        {
            InitializeComponent();
            
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameTb.Text == "" || SurnameTb.Text == "" || PatronymicTb.Text == "" || BirthdayDp.Text == "" || SeriesTb.Text == "" || NumbersTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Заполните все поля!!!");
            }
            else
            {
                clients.Name = NameTb.Text;
                clients.Surname = SurnameTb.Text;
                clients.Patronymic = PatronymicTb.Text;
                clients.Birthday = Convert.ToDateTime(BirthdayDp.Text);
                clients.PasportNumber = NumbersTb.Text;
                clients.PasportSeries = SeriesTb.Text;
                clients.Phone = PhoneTb.Text;
                DBConnection.TouristsGo.Clients.Add(clients);
                DBConnection.TouristsGo.SaveChanges();
                this.Close();
            }
            

        }
    }
}
