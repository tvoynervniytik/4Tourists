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
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public static List<Employee> Employees = new List<Employee>();
        public static Employee employee1 = new Employee();
        Employee contextEmployee;
        public static Employee employees { get; set; }


        private void InitializeDataInPage()
        {
            Employees = new List<Employee>(DBConnection.TouristsGo.Employee.ToList());
            PostEmpCb.ItemsSource = DBConnection.TouristsGo.Post.ToList();
            PhoneEmpTb.Text = DBConnection.TouristsGo.Employee.ToList().ToString();
            NameEmpTb.Text = DBConnection.TouristsGo.Employee.ToList().ToString();
            SurnameEmpTb.Text = DBConnection.TouristsGo.Employee.ToList().ToString();
            PatronymicEmpTb.Text = DBConnection.TouristsGo.Employee.ToList().ToString();
            BirthdayEmpDp.Text = DBConnection.TouristsGo.Employee.ToList().ToString();
            LoginEmpTb.Text = DBConnection.TouristsGo.Employee.ToList().ToString();
            PasswordEmpTb.Text = DBConnection.TouristsGo.Employee.ToList().ToString();

        }
        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            employee1 = employee;
            contextEmployee = employee;
            employees = employee;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void EditEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = employee1;
            if (NameEmpTb.Text == "" || SurnameEmpTb.Text == "" || PatronymicEmpTb.Text == "" || BirthdayEmpDp.Text == "" || PostEmpCb.Text == "" || PhoneEmpTb.Text == "" || PhoneEmpTb.Text == "" || LoginEmpTb.Text == "" || PasswordEmpTb.Text == "")
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
                DBConnection.TouristsGo.SaveChanges();
                NameEmpTb.Text = String.Empty;
                SurnameEmpTb.Text = String.Empty;
                PatronymicEmpTb.Text = String.Empty;
                BirthdayEmpDp = null;
                PhoneEmpTb.Text = String.Empty;
                PostEmpCb.Text = String.Empty;
                LoginEmpTb.Text = String.Empty;
                PasswordEmpTb.Text = String.Empty;

                Close();



            }
        }
    }
}
