using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для FindPlaintiffByPasport.xaml
    /// </summary>
    public partial class FindPlaintiffByPasport : Window
    {
        Context db = new Context();

        public FindPlaintiffByPasport()
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

                db.Plaintiffs.Where(d => d.PasportSeries == series && d.PasportNum == num).Load();
                mw.UpdatePlaintiffDataGrid(db);
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
