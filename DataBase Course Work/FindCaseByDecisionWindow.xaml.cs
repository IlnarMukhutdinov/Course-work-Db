using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;


namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для FindCaseByDecisionWindow.xaml
    /// </summary>
    public partial class FindCaseByDecisionWindow : Window
    {
        Context db = new Context();

        public FindCaseByDecisionWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = Owner as MainWindow;
            try
            {
                db.CourtCases.Where(c => c.Decision == Condition.Text).Load();
                mw.UpdateCourtCaseDataGrid(db);
                Close();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }

        }
    }
}
