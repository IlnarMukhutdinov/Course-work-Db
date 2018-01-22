using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для FindDefendantByPasport.xaml
    /// </summary>
    public partial class FindDefendantByPasport : Window
    {
        Context db = new Context();
        public FindDefendantByPasport()
        {
            InitializeComponent();
            PasportSeries.Text = "0";
            PasportNum.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int series = int.Parse(PasportSeries.Text);
            int num = int.Parse(PasportNum.Text);

            db.Defendants.Where(d => d.PasportSeries == series && d.PasportNum == num).Load();
            MainWindow mw = new MainWindow { MainGrid = { ItemsSource = db.Defendants.Local.ToBindingList() } };
            mw.Show();
            Close();
        }
    }
}
