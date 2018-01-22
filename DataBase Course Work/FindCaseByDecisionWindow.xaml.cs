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
            db.CourtCases.Where(c => c.Decision == Condition.Text).Load();
            MainWindow mw = new MainWindow {MainGrid = {ItemsSource = db.CourtCases.Local.ToBindingList()}};
            mw.Show();
            Close();
        }
    }
}
