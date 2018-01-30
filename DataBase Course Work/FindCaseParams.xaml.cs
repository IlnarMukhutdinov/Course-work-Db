using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DataBase_Course_Work
{
    public partial class FindCaseParams
    {
        public FindCaseParams()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int year, month, day;
            try
            {
                year = int.Parse(TextBoxYear.Text);
                month = int.Parse(TextBoxMonth.Text);
                day = int.Parse(TextBoxDay.Text);
                StaticDataContext.DataContext.CourtCases
                    .Where(c => c.StartDateTime.Year == year && c.StartDateTime.Month == month &&
                                c.StartDateTime.Day == day)
                    .Load();
                new MainWindow().UpdateCourtCaseDataGrid(StaticDataContext.DataContext);
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
