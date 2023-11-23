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
    /// Логика взаимодействия для AddPromocodesWindow.xaml
    /// </summary>
    public partial class AddPromocodesWindow : Window
    {
        public static List<Promocode> promocodes { get; set; }
        public AddPromocodesWindow()
        {
            InitializeComponent();
            promocodes = new List<Promocode>(DBConnection.TouristsGo.Promocode.ToList());
            this.DataContext = this;

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Promocode promocod = new Promocode();
            promocod.Description = NamePromTB.Text.Trim();
            promocod.Procent =  int.Parse(ProcentTB.Text.Trim());

            DBConnection.TouristsGo.Promocode.Add(promocod);
            DBConnection.TouristsGo.SaveChanges();
        }
    }
}
