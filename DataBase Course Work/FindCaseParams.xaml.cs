using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace DataBase_Course_Work
{
    public partial class FindCaseParams : Window
    {
        private Context db = new Context();

        public FindCaseParams()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int year, month, day;
            MainWindow mw = Owner as MainWindow;
            try
            {
                year = int.Parse(TextBox_Year.Text);
                month = int.Parse(TextBox_Month.Text);
                day = int.Parse(TextBox_Day.Text);
                db.CourtCases
                    .Where(c => c.StartDateTime.Year == year && c.StartDateTime.Month == month &&
                                c.StartDateTime.Day == day)
                    .Load();
                mw.UpdateCourtCaseDataGrid(db);
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
