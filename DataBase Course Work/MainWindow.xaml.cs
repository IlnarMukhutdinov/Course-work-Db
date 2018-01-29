using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace DataBase_Course_Work
{
    public partial class MainWindow : Window
    {
        private Context _dataContext;

        public MainWindow()
        {
            InitializeComponent();
            _dataContext = new Context();
            DefaultInfoInDb defaultInfo = new DefaultInfoInDb();
            //_dataContext = defaultInfo.CreateDefaultCaseMaterial();
            //_dataContext = defaultInfo.CreateDefaultCourtCase();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _dataContext.Dispose();
        }

        private void ItemCourtCase_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.CourtCases.Load();
            MainGrid.ItemsSource = _dataContext.CourtCases.Local.ToBindingList();
        }

        private void ItemEmployee_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Employees.Load();
            MainGrid.ItemsSource = _dataContext.Employees.Local.ToBindingList();
        }

        private void ItemProtocol_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Protocols.Load();
            MainGrid.ItemsSource = _dataContext.Protocols.Local.ToBindingList();
        }

        private void ItemCaseMaterials_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.CaseMaterials.Load();
            MainGrid.ItemsSource = _dataContext.CaseMaterials.Local.ToBindingList();
        }

        private void ItemPlaintiff_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Plaintiffs.Load();
            MainGrid.ItemsSource = _dataContext.Plaintiffs.Local.ToBindingList();
        }

        private void ItemDefendant_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Defendants.Load();
            MainGrid.ItemsSource = _dataContext.Defendants.Local.ToBindingList();
        }

        private void BtnUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            _dataContext.SaveChanges();
        }

        private void ItemCourtCaseDelete_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Database.ExecuteSqlCommand("DELETE FROM [CourtCases]");
        }

        private void ItemEmployeeDelete_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Database.ExecuteSqlCommand("DELETE FROM [Employees]");
        }

        private void ItemProtocolDelete_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Database.ExecuteSqlCommand("DELETE FROM [Protocols]");
        }

        private void ItemCaseMaterialsDelete_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Database.ExecuteSqlCommand("DELETE FROM [CaseMaterials]");
        }

        private void ItemPlaintiffDelete_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Database.ExecuteSqlCommand("DELETE FROM [Plaintiffs]");
        }

        private void ItemDefendantDelete_Selected(object sender, RoutedEventArgs e)
        {
            _dataContext.Database.ExecuteSqlCommand("DELETE FROM [Defendants]");
        }
        
        private void ItemFindCaseByDate_Selected(object sender, RoutedEventArgs e)
        {
            FindCaseParams fcp = new FindCaseParams() {Owner = this};
            fcp.Show();
        }

        private void ItemFindCaseByDecision_Selected(object sender, RoutedEventArgs e)
        {
            FindCaseByDecisionWindow fcbd = new FindCaseByDecisionWindow() {Owner = this};
            fcbd.Show();
        }

        private void ItemFindEmployeeBySecondName_Selected(object sender, RoutedEventArgs e)
        {
            FindEmployeeBySecondName febsn = new FindEmployeeBySecondName() {Owner = this};
            febsn.Show();
        }

        private void ItemFindDefendantByPasport_Selected(object sender, RoutedEventArgs e)
        {
            FindDefendantByPasport fdbp = new FindDefendantByPasport() {Owner = this};
            fdbp.Show();
        }

        private void ItemFindPlaintiffByPasport_Selected(object sender, RoutedEventArgs e)
        {
            FindPlaintiffByPasport fpbp = new FindPlaintiffByPasport() {Owner = this};
            fpbp.Show();
        }

        public void UpdateCourtCaseDataGrid(Context db)
        {
            MainGrid.ItemsSource = db.CourtCases.Local.ToBindingList();
        }

        public void UpdateDefendantDataGrid(Context db)
        {
            MainGrid.ItemsSource = db.Defendants.Local.ToBindingList();
        }

        public void UpdateEmployeeDataGrid(Context db)
        {
            MainGrid.ItemsSource = db.Employees.Local.ToBindingList();
        }

        public void UpdatePlaintiffDataGrid(Context db)
        {
            MainGrid.ItemsSource = db.Plaintiffs.Local.ToBindingList();
        }

        private void MainGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName) && displayName != "none")
            {
                e.Column.Header = displayName;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private string GetPropertyDisplayName(object ePropertyDescriptor)
        {
            if (ePropertyDescriptor is PropertyDescriptor pd)
            {
                if (pd.Attributes[typeof(DisplayNameAttribute)] is DisplayNameAttribute displayName && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }
                if (pd.Attributes[typeof(DesignOnlyAttribute)] is DesignOnlyAttribute designOnly && designOnly.IsDesignOnly)
                {
                    return "none";
                }
            }
            return null;
        }

        private void BtnFillDefaultInfo_Click(object sender, RoutedEventArgs e)
        {
            DefaultInfoInDb defaultInfo = new DefaultInfoInDb();
            _dataContext = defaultInfo.CreateDefaultEmployee();
            _dataContext = defaultInfo.CreateDefaultDefendant();
            _dataContext = defaultInfo.CreateDefaultPlaintiff();
            _dataContext = defaultInfo.CreateDefaultCaseMaterial();
            _dataContext = defaultInfo.CreateDefaultProtocol();
            _dataContext = defaultInfo.CreateDefaultCourtCase();
            _dataContext.SaveChanges();
        }
    }
}
