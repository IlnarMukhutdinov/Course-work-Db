using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для FindCaseParams.xaml
    /// </summary>
    public partial class FindCaseParams : Window
    {
        Context db = new Context();

        public FindCaseParams()
        {
            InitializeComponent();
            TextBox_Year.Text = "0";
            TextBox_Month.Text = "0";
            TextBox_Day.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(TextBox_Year.Text);
            int month = int.Parse(TextBox_Month.Text);
            int day = int.Parse(TextBox_Day.Text);
            db.CourtCases
                .Where(c => c.StartDateTime.Year == year && c.StartDateTime.Month == month && c.StartDateTime.Day == day)
                .Load();
            MainWindow mw = new MainWindow();
            mw.MainGrid.ItemsSource = db.CourtCases.Local.ToBindingList();
            mw.Show();
            FindCaseByDate.Close();
        }
    }
}
