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
            db.Employees.Where(c => c.SecondName == Condition.Text).Load();
            MainWindow mw = new MainWindow { MainGrid = { ItemsSource = db.Employees.Local.ToBindingList() } };
            mw.Show();
            Close();
        }
    }
}
