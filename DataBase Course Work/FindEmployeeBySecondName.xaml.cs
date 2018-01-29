using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для FindEmployeeBySecondName.xaml
    /// </summary>
    public partial class FindEmployeeBySecondName : Window
    {
        Context db = new Context();

        public FindEmployeeBySecondName()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mw = Owner as MainWindow;
                db.Employees.Where(c => c.SecondName == Condition.Text).Load();
                mw.UpdateEmployeeDataGrid(db);
                Close();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
