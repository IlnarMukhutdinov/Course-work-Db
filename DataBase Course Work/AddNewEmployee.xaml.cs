using System;
using System.Windows;

namespace DataBase_Course_Work
{
    public partial class AddNewEmployee : Window
    {
        private Employee _employee = new Employee();

        public AddNewEmployee()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _employee.FirstName = TextBoxFirstName.Text;
                _employee.SecondName = TextBoxSecondName.Text;
                _employee.LastName = TextBoxLastName.Text;
                _employee.BirthDay = new DateTime(int.Parse(TextBoxYear.Text), int.Parse(TextBoxMonth.Text), int.Parse(TextBoxDay.Text));
                _employee.Location = TextBoxLocation.Text;
                _employee.Post = TextBoxPost.Text;
                StaticDataContext.DataContext.Employees.Add(_employee);
                new MainWindow().UpdateEmployeeDataGrid(StaticDataContext.DataContext);
                ClearFields();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
        }

        private void ClearFields()
        {
            TextBoxYear.Clear();
            TextBoxMonth.Clear();
            TextBoxDay.Clear();
            TextBoxFirstName.Clear();
            TextBoxSecondName.Clear();
            TextBoxLastName.Clear();
            TextBoxLocation.Clear();
            TextBoxPost.Clear();
        }
    }
}
