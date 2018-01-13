using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreateDeffaultDb_Click(object sender, RoutedEventArgs e)
        {
            BtnCreateDeffaultDb.IsEnabled = false;
            BtnClearDb.IsEnabled = true;
            MenuLabel.Visibility = Visibility.Visible;
            Menu.Visibility = Visibility.Visible;

            CourtCase courtCase = new CourtCase();
            Employee employee = new Employee();
            Protocol protocol = new Protocol();
            CaseMaterial caseMaterial = new CaseMaterial();
            Plaintiff plaintiff = new Plaintiff();
            Defendant defendant = new Defendant();

            defendant.FirstName = "Вино";
            defendant.BirthDay = DateTime.Now;
            Context context = new Context();
            
            context.Defendants.Add(defendant);
            
            context.SaveChanges();
        }
    }
}
