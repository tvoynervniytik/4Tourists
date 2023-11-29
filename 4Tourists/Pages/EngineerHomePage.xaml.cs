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
    /// Логика взаимодействия для EngineerHomePage.xaml
    /// </summary>
    public partial class EngineerHomePage : Page
    {
        public static List<Employee> employees { get; set; }
        public static List<Post> posts { get; set; }
        public static Employee editEmployee = new Employee();
        public static Employee employeeDel = new Employee();

        public EngineerHomePage()
        {
            InitializeComponent();
            employees = new List<Employee>(DBConnection.TouristsGo.Employee.ToList());
            this.DataContext = this;

        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            editEmployee = EmployeesSlv.SelectedItem as Employee;
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(editEmployee);
            addEmployeeWindow.Show();
        }
        public static void DeleteEmployee(Employee employee)
        {

            DBConnection.TouristsGo.Employee.Remove(employee);
            DBConnection.TouristsGo.SaveChanges();


        }
        public static List<Employee> SourceStudentsList(Employee employee)
        {
            return new List<Employee>(DBConnection.TouristsGo.Employee.ToList());
        }
        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesSlv.SelectedItem != null)
            {
                DeleteEmployee(EmployeesSlv.SelectedItem as Employee);
                EmployeesSlv.SelectedItem = null;
                EmployeesSlv.ItemsSource = SourceStudentsList(employeeDel);
            }
            else
            {
                MessageBox.Show("Выберите работника для удаления");
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            employees = new List<Employee>(DBConnection.TouristsGo.Employee.ToList());
            EmployeesSlv.ItemsSource = employees;
        }


        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            if (EmployeesSlv.SelectedItem != null)
            {
                editEmployee = EmployeesSlv.SelectedItem as Employee;
                EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(editEmployee);
                editEmployeeWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите работника для редактирования");
            }
        }
}
