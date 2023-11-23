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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4Tourists.Pages
{
    /// <summary>
    /// Логика взаимодействия для PromocodesPage.xaml
    /// </summary>
    public partial class PromocodesPage : Page
    {
        public static List<Promocode> promocodes { get; set; }
        public PromocodesPage()
        {
            InitializeComponent();
            promocodes = new List<Promocode>(DBConnection.TouristsGo.Promocode.ToList());
            this.DataContext = this;
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Promocodeslv.SelectedItem is Promocode promocodes)
            {
                DBConnection.TouristsGo.Promocode.Remove(promocodes);
                DBConnection.TouristsGo.SaveChanges();
                Promocodeslv.ItemsSource = DBConnection.TouristsGo.Promocode.ToList();
            }
        }
    }
}
