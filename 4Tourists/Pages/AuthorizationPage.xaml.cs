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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Employee> employees { get; set; }
        public static List<Post> posts { get; set; }
        public static Employee currentUser;
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            employees = new List<Employee>(DBConnection.TouristsGo.Employee.ToList());
            Employee currentUser = employees.FirstOrDefault(i => i.Login == login && i.Password == password);

            if (currentUser != null)
            {
                posts = new List<Post>(DBConnection.TouristsGo.Post.ToList());
                Post curpost = posts.FirstOrDefault(i => i.Id == currentUser.IdPost);
                string post = curpost.Name;
                if (currentUser != null)
                {
                    MessageBox.Show(post);
                    if (currentUser.IdPost == 11)
                    {
                        NavigationService.Navigate(new AdminHomePage());
                    }
                    if (currentUser.IdPost == 12)
                    {
                        NavigationService.Navigate(new EngineerHomePage());
                    }
                }
                else
                    MessageBox.Show("All's wrong");
            }
            else
                MessageBox.Show("!!!Заполни данные, АЛО!!!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage());
        }
    }
}
