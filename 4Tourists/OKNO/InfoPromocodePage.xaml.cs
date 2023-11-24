using _4Tourists.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для InfoPromocodePage.xaml
    /// </summary>
    public partial class InfoPromocodePage : Window
    {
        public static List<Promocode> promocodes { get; set; }
        Promocode contextPromocode;
        public static Promocode pro { get; set; }
        public InfoPromocodePage(Promocode promocode)
        {
            InitializeComponent();
            contextPromocode = promocode;
            pro = promocode;
            InitializeDataInPage();
            this.DataContext = this;
        }
        private void InitializeDataInPage()
        {
            promocodes = new List<Promocode>(DBConnection.TouristsGo.Promocode.ToList());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var val = new ValidationContext(contextPromocode);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateObject(contextPromocode, val, results, true))
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
            if (contextPromocode.Promocode1 == 0)
                DBConnection.TouristsGo.Promocode.Add(contextPromocode);
            DBConnection.TouristsGo.SaveChanges();
            this.Close();
        }
    }
}
