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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public static List<Employee> employeeList = new List<Employee>();
        public static DB.Employee employee = new DB.Employee();
        public static List<Post> postList = new List<Post>();
        public static DB.Post Post = new DB.Post();
        public static Employee employee1 = new Employee();

        public AddEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            employee1 = employee;
            postList = new List<Post>(DBConnection.TouristsGo.Post.ToList());
            PostEmpCb.ItemsSource = postList;


        }


        private void AddEmpBtn_Click(object sender, RoutedEventArgs e)
        {

            if (NameEmpTb.Text == "" || SurnameEmpTb.Text == "" || PatronymicEmpTb.Text == "" || BirthdayEmpDp.Text == "" || PhoneEmpTb.Text == "" || PhoneEmpTb.Text == "" || LoginEmpTb.Text == "" || PasswordEmpTb.Text == "")
            {
                MessageBox.Show("Заполните все данные!!!");
            }
            else
            {
                employee.Name = NameEmpTb.Text;
                employee.Surname = SurnameEmpTb.Text;
                employee.Patronymic = PatronymicEmpTb.Text;
                employee.Birthday = Convert.ToDateTime(BirthdayEmpDp.Text);
                employee.Phone = PhoneEmpTb.Text;
                employee.IdPost = (PostEmpCb.SelectedItem as Post).Id;
                employee.Login = LoginEmpTb.Text;
                employee.Password = PasswordEmpTb.Text;
                DBConnection.TouristsGo.Employee.Add(employee);
                DBConnection.TouristsGo.SaveChanges();
                Close();

            }
        }
}
