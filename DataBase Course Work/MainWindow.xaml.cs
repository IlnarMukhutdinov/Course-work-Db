using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace DataBase_Course_Work
{
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            StaticDataContext.DataContext.Dispose();
        }

        private void ItemCourtCase_Selected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.DataContext.CourtCases.Load();
            MainGrid.ItemsSource = StaticDataContext.DataContext.CourtCases.Local.ToBindingList();
        }

        private void ItemEmployee_Selected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.DataContext.Employees.Load();
            MainGrid.ItemsSource = StaticDataContext.DataContext.Employees.Local.ToBindingList();
        }

        private void ItemProtocol_Selected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.DataContext.Protocols.Load();
            MainGrid.ItemsSource = StaticDataContext.DataContext.Protocols.Local.ToBindingList();
        }

        private void ItemCaseMaterials_Selected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.DataContext.CaseMaterials.Load();
            MainGrid.ItemsSource = StaticDataContext.DataContext.CaseMaterials.Local.ToBindingList();
        }

        private void ItemPlaintiff_Selected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.DataContext.Plaintiffs.Load();
            MainGrid.ItemsSource = StaticDataContext.DataContext.Plaintiffs.Local.ToBindingList();
        }

        private void ItemDefendant_Selected(object sender, RoutedEventArgs e)
        {
            BtnAddNewData.IsEnabled = true;
            BtnUpdateDb.IsEnabled = true;
            StaticDataContext.DataContext.Defendants.Load();
            MainGrid.ItemsSource = StaticDataContext.DataContext.Defendants.Local.ToBindingList();
        }

        private void BtnUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.SaveChanges();
            new SuccessSaving().Show();
        }

        private void ItemCourtCaseDelete_Selected(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.Database.ExecuteSqlCommand("DELETE FROM [CourtCases]");
        }

        private void ItemEmployeeDelete_Selected(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.Database.ExecuteSqlCommand("DELETE FROM [Employees]");
        }

        private void ItemProtocolDelete_Selected(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.Database.ExecuteSqlCommand("DELETE FROM [Protocols]");
        }

        private void ItemCaseMaterialsDelete_Selected(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.Database.ExecuteSqlCommand("DELETE FROM [CaseMaterials]");
        }

        private void ItemPlaintiffDelete_Selected(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.Database.ExecuteSqlCommand("DELETE FROM [Plaintiffs]");
        }

        private void ItemDefendantDelete_Selected(object sender, RoutedEventArgs e)
        {
            StaticDataContext.DataContext.Database.ExecuteSqlCommand("DELETE FROM [Defendants]");
        }

        private void ItemFindCaseByDate_Selected(object sender, RoutedEventArgs e)
        {
            FindCaseParams fcp = new FindCaseParams();
            fcp.Show();
        }

        private void ItemFindCaseByDecision_Selected(object sender, RoutedEventArgs e)
        {
            FindCaseByDecisionWindow fcbd = new FindCaseByDecisionWindow() { Owner = this };
            fcbd.Show();
        }

        private void ItemFindEmployeeBySecondName_Selected(object sender, RoutedEventArgs e)
        {
            FindEmployeeBySecondName febsn = new FindEmployeeBySecondName() { Owner = this };
            febsn.Show();
        }

        private void ItemFindDefendantByPasport_Selected(object sender, RoutedEventArgs e)
        {
            FindDefendantByPasport fdbp = new FindDefendantByPasport() { Owner = this };
            fdbp.Show();
        }

        private void ItemFindPlaintiffByPasport_Selected(object sender, RoutedEventArgs e)
        {
            FindPlaintiffByPasport fpbp = new FindPlaintiffByPasport() { Owner = this };
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

        public void UpdateCaseMaterialDataGrid(Context db)
        {
            MainGrid.ItemsSource = db.CaseMaterials.Local.ToBindingList();
        }

        public void UpdateProtocolDataGrid(Context db)
        {
            MainGrid.ItemsSource = db.Protocols.Local.ToBindingList();
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

            StaticDataContext.DataContext = defaultInfo.CreateDefaultEmployee();
            StaticDataContext.DataContext.SaveChanges();

            StaticDataContext.DataContext = defaultInfo.CreateDefaultDefendant();
            StaticDataContext.DataContext.SaveChanges();

            StaticDataContext.DataContext = defaultInfo.CreateDefaultPlaintiff();
            StaticDataContext.DataContext.SaveChanges();

            StaticDataContext.DataContext = defaultInfo.CreateDefaultCaseMaterial();
            StaticDataContext.DataContext.SaveChanges();

            StaticDataContext.DataContext = defaultInfo.CreateDefaultProtocol();
            StaticDataContext.DataContext.SaveChanges();

            StaticDataContext.DataContext = defaultInfo.CreateDefaultCourtCase();
            StaticDataContext.DataContext.SaveChanges();
        }

        private void BtnAddNewData_Click(object sender, RoutedEventArgs e)
        {
            if (ItemCourtCase.IsSelected)
            {
                new AddNewCourtCase().Show();
            }
            else if (ItemEmployee.IsSelected)
            {
                new AddNewEmployee().Show();
            }
            else if (ItemCaseMaterials.IsSelected)
            {
                new AddNewCaseMaterial().Show();
            }
            else if (ItemDefendant.IsSelected)
            {
                new AddNewDefendant().Show();
            }
            else if(ItemPlaintiff.IsSelected)
            {
                new AddNewPlaintiff().Show();
            }
            else
            {
                new AddNewProtocol().Show();
            }
        }
    }
}
