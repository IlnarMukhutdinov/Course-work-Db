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
        private readonly Context dataContext;
        private CourtCase courtCase;
        private Employee employee;
        private Protocol protocol;
        private CaseMaterial caseMaterial;
        private Plaintiff plaintiff;
        private Defendant defendant;
        private FindCaseParams fcParams;

        public MainWindow()
        {
            InitializeComponent();
            dataContext = new Context();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //CreateDefaultInfoInDB();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            dataContext.Dispose();
        }

        private void ItemCourtCase_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.CourtCases.Load();
            MainGrid.ItemsSource = dataContext.CourtCases.Local.ToBindingList();
        }

        private void ItemEmployee_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Employees.Load();
            MainGrid.ItemsSource = dataContext.Employees.Local.ToBindingList();
        }

        private void Protocol_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Protocols.Load();
            MainGrid.ItemsSource = dataContext.Protocols.Local.ToBindingList();
        }

        private void CaseMaterials_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.CaseMaterials.Load();
            MainGrid.ItemsSource = dataContext.CaseMaterials.Local.ToBindingList();
        }

        private void Plaintiff_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Plaintiffs.Load();
            MainGrid.ItemsSource = dataContext.Plaintiffs.Local.ToBindingList();
        }

        private void Defendant_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Defendants.Load();
            MainGrid.ItemsSource = dataContext.Defendants.Local.ToBindingList();
        }

        private void btn_UpdateDB_Click(object sender, RoutedEventArgs e)
        {
            dataContext.SaveChanges();
        }

        private void ItemCourtCaseDelete_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Database.ExecuteSqlCommand("DELETE FROM [CourtCases]");
        }

        private void ItemEmployeeDelete_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Database.ExecuteSqlCommand("DELETE FROM [Employees]");
        }

        private void ItemProtocolDelete_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Database.ExecuteSqlCommand("DELETE FROM [Protocols]");
        }

        private void ItemCaseMaterialsDelete_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Database.ExecuteSqlCommand("DELETE FROM [CaseMaterials]");
        }

        private void ItemPlaintiffDelete_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Database.ExecuteSqlCommand("DELETE FROM [Plaintiffs]");
        }

        private void ItemDefendantDelete_Selected(object sender, RoutedEventArgs e)
        {
            dataContext.Database.ExecuteSqlCommand("DELETE FROM [Defendants]");
        }

        private void CreateDefaultInfoInDB()
        {
            courtCase = new CourtCase();
            string[] firstnames = {"Донна", "Хелен", "Элис", "Энн", "Кларисса", "Линда", "Мэрилинн"};
            string[] secondnames = {"Хортон", "Маккой", "Уолтон", "Бэйкер", "Митчелл", "Итон", "Паркс"};
            string[] lastnames = {"Джулия", "Кэролайн", "Дженнифер", "Дороти", "Эмбер", "Беверли", "Джейд"};
            string[] streets = {
                "694 W. Charles Street ", "93 Franklin St. ",
                "9845 S. Devonshire Drive", "594 Charles Ave. ",
                "915 NW. Cooper St.", "7701 Acacia Lane",
                "7650 West Hawthorne Avenue", "57 Manor Dr.",
                "675 NE. Mill Pond Circle", "78 S. St Louis Street"
            };
            employee = new Employee
            {
                FirstName = "Джайлс",
                SecondName = "Хайнс",
                LastName = "Питер",
                BirthDay = new DateTime(1977, 3, 6),
                Location = "Wayne, NJ 07470",
                Post = "Судья"
            };
            dataContext.Employees.Add(employee);
            
            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                employee = new Employee
                {
                    FirstName = firstnames[rnd.Next(0, firstnames.Length)],
                    SecondName = secondnames[rnd.Next(0, secondnames.Length)],
                    LastName = lastnames[rnd.Next(0, lastnames.Length)],
                    BirthDay = new DateTime(rnd.Next(1970, 1997), rnd.Next(1, 11), rnd.Next(1, 25)),
                    Location = streets[rnd.Next(0, streets.Length)],
                    Post = "Секретарь"
                };
                dataContext.Employees.Add(employee);
            }

            for (int i = 0; i < 5; i++)
            {
                plaintiff = new Plaintiff
                {
                    FirstName = firstnames[rnd.Next(0, firstnames.Length)],
                    SecondName = secondnames[rnd.Next(0, secondnames.Length)],
                    LastName = lastnames[rnd.Next(0, lastnames.Length)],
                    BirthDay = new DateTime(rnd.Next(1970, 1997), rnd.Next(1, 11), rnd.Next(1, 25)),
                    PasportNum = rnd.Next(44, 55),
                    PasportSeries = rnd.Next(44444, 99999)
                };
                dataContext.Plaintiffs.Add(plaintiff);
            }

            for (int i = 0; i < 5; i++)
            {
                defendant = new Defendant
                {
                    FirstName = firstnames[rnd.Next(0, firstnames.Length)],
                    SecondName = secondnames[rnd.Next(0, secondnames.Length)],
                    LastName = lastnames[rnd.Next(0, lastnames.Length)],
                    BirthDay = new DateTime(rnd.Next(1970, 1997), rnd.Next(1, 11), rnd.Next(1, 25)),
                    PasportNum = rnd.Next(44, 55),
                    PasportSeries = rnd.Next(44444, 99999)
                };
                dataContext.Defendants.Add(defendant);
            }
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
    }
}
