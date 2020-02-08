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
using AssignmentEF03.Models;
using AssignmentEF03.DAL;
using AssignmentEF03.Views;

namespace AssignmentEF03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> employeeList = null;
        private EmployeeDal eDal = null;

        public MainWindow()
        {
            InitializeComponent();

            Model db = new Model();
            eDal = new EmployeeDal(db);
        }

        private void ShowEmployees()
        {
            employeeList = eDal.ReturnEmployees();
            ListBox1.ItemsSource = null;
            ListBox1.ItemsSource = employeeList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowEmployees();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex > -1) 
            {
                Employee e1 = ListBox1.SelectedItem as Employee;

                TextBoxFirstName.Text = e1.FirstName;
                TextBoxLastName.Text = e1.LastName;
                TextBoxDateOfBirth.Text = e1.BirthDate.ToString();
            }
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            WindowNewEmployee w1 = new WindowNewEmployee();
            w1.Title = "Enter employee information";
            w1.Owner = this;

            if(w1.ShowDialog()==true)
            {
                Employee e1 = w1.Employee;

                int id = eDal.InsertEmployee(e1);

                if (id != -1) 
                {
                    ShowEmployees();
                    ListBox1.SelectedIndex = employeeList
                        .FindIndex(a => a.EmployeeID == id);
                    MessageBox.Show("New employee added");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Select employee");
                return;
            }

            Employee editEmployee = ListBox1.SelectedItem as Employee;

            WindowNewEmployee w1 = new WindowNewEmployee();
            w1.Title = "Edit employee data";
            w1.Owner = this;
            int id = editEmployee.EmployeeID;
            w1.Employee = editEmployee;

            if (w1.ShowDialog() == true)
            {
                editEmployee = w1.Employee;
                editEmployee.EmployeeID = id;

                int result = eDal.ChangeEmployee(editEmployee);

                if (result == 0)
                {
                    ShowEmployees();
                    ListBox1.SelectedIndex = employeeList
                        .FindIndex(a => a.EmployeeID == id);
                    MessageBox.Show("Employee data changed");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
           
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Select employee");
                return;
            }

            Employee e1 = ListBox1.SelectedItem as Employee;

            MessageBoxResult mbr = MessageBox.Show("Delete employee: " + e1.ToString(), "Delete", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            int result = eDal.DeleteEmployee(e1);

            if (result == 0)
            {
                ShowEmployees();
                TextBoxFirstName.Clear();
                TextBoxLastName.Clear();
                TextBoxDateOfBirth.Clear();
                MessageBox.Show("Employee deleted");
            }

            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
