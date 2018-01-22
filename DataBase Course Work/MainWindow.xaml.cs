using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Context db;
        public CourtCase courtCase;
        public Employee employee;
        public Protocol protocol;
        public CaseMaterial caseMaterial;
        public Plaintiff plaintiff;
        public Defendant defendant;
        public FindCaseParams fcParams;

        public MainWindow()
        {
            InitializeComponent();
            db = new Context();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //CreateDefaultInfoInDB();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }

        private void ItemCourtCase_Selected(object sender, RoutedEventArgs e)
        {
            db.CourtCases.Load();
            MainGrid.ItemsSource = db.CourtCases.Local.ToBindingList();
        }

        private void ItemEmployee_Selected(object sender, RoutedEventArgs e)
        {
            db.Employees.Load();
            MainGrid.ItemsSource = db.Employees.Local.ToBindingList();
        }

        private void Protocol_Selected(object sender, RoutedEventArgs e)
        {
            db.Protocols.Load();
            MainGrid.ItemsSource = db.Protocols.Local.ToBindingList();
        }

        private void CaseMaterials_Selected(object sender, RoutedEventArgs e)
        {
            db.CaseMaterials.Load();
            MainGrid.ItemsSource = db.CaseMaterials.Local.ToBindingList();
        }

        private void Plaintiff_Selected(object sender, RoutedEventArgs e)
        {
            db.Plaintiffs.Load();
            MainGrid.ItemsSource = db.Plaintiffs.Local.ToBindingList();
        }

        private void Defendant_Selected(object sender, RoutedEventArgs e)
        {
            db.Defendants.Load();
            MainGrid.ItemsSource = db.Defendants.Local.ToBindingList();
        }

        private void btn_UpdateDB_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void ItemCourtCaseDelete_Selected(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [CourtCases]");
        }

        private void ItemEmployeeDelete_Selected(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [Emplopyees]");
        }

        private void ItemProtocolDelete_Selected(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [Protocols]");
        }

        private void ItemCaseMaterialsDelete_Selected(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [CaseMaterials]");
        }

        private void ItemPlaintiffDelete_Selected(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [Plaintiffs]");
        }

        private void ItemDefendantDelete_Selected(object sender, RoutedEventArgs e)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM [Defendants]");
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
            db.Employees.Add(employee);
            
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
                db.Employees.Add(employee);
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
                db.Plaintiffs.Add(plaintiff);
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
                db.Defendants.Add(defendant);
            }
        }

        private void ItemFindCaseByDate_Selected(object sender, RoutedEventArgs e)
        {
            fcParams = new FindCaseParams();
            fcParams.Show();
            Close();
        }

        private void ItemFindCaseByDecision_Selected(object sender, RoutedEventArgs e)
        {
            FindCaseByDecisionWindow fc = new FindCaseByDecisionWindow();
            fc.Show();
            Close();
        }

        private void ItemFindEmployeeBySecondName_Selected(object sender, RoutedEventArgs e)
        {
            FindEmployeeBySecondName fe = new FindEmployeeBySecondName();
            fe.Show();
            Close();
        }

        private void ItemFindDefendantByPasport_Selected(object sender, RoutedEventArgs e)
        {
            FindDefendantByPasport fd = new FindDefendantByPasport();
            fd.Show();
            Close();
        }

        private void ItemFindPlaintiffByPasport_Selected(object sender, RoutedEventArgs e)
        {
            FindPlaintiffByPasport fp = new FindPlaintiffByPasport();
            fp.Show();
            Close();
        }
    }
}
