using System;
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
        private Context db = new Context();

        public FindDefendantByPasport()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = Owner as MainWindow;
            int series, num;
            try
            {
                series = int.Parse(PasportSeries.Text);
                num = int.Parse(PasportNum.Text);
                db.Defendants.Where(d => d.PasportSeries == series && d.PasportNum == num).Load();
                mw.UpdateDefendantDataGrid(db);
                Close();
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
    }
}
