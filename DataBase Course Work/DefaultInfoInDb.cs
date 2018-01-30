using System;

namespace DataBase_Course_Work
{
    class DefaultInfoInDb
    {
        public Context DataContext = new Context();

        private CourtCase _courtCase;

        private Employee _employee;

        private Protocol _protocol;

        private CaseMaterial _caseMaterial;

        private Plaintiff _plaintiff;

        private Defendant _defendant;

        private readonly string[] _firstnames = { "Донна", "Хелен", "Элис", "Энн", "Кларисса", "Линда", "Мэрилинн" };

        private readonly string[] _secondnames = { "Хортон", "Маккой", "Уолтон", "Бэйкер", "Митчелл", "Итон", "Паркс" };

        private readonly string[] _lastnames = { "Джулия", "Кэролайн", "Дженнифер", "Дороти", "Эмбер", "Беверли", "Джейд" };

        private readonly string[] _streets = {"694 W. Charles Street ", "93 Franklin St. ", "9845 S. Devonshire Drive", "594 Charles Ave. ",
            "915 NW. Cooper St.", "7701 Acacia Lane", "7650 West Hawthorne Avenue", "57 Manor Dr.", "675 NE. Mill Pond Circle", "78 S. St Louis Street" };

        public Context CreateDefaultEmployee()
        {
            _employee = new Employee
            {
                FirstName = "Джайлс",
                SecondName = "Хайнс",
                LastName = "Питер",
                BirthDay = new DateTime(1977, 3, 6),
                Location = "Wayne, NJ 07470",
                Post = "Судья"
            };
            DataContext.Employees.Add(_employee);

            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                _employee = new Employee
                {
                    FirstName = _firstnames[rnd.Next(0, _firstnames.Length)],
                    SecondName = _secondnames[rnd.Next(0, _secondnames.Length)],
                    LastName = _lastnames[rnd.Next(0, _lastnames.Length)],
                    BirthDay = new DateTime(rnd.Next(1970, 1997), rnd.Next(1, 11), rnd.Next(1, 25)),
                    Location = _streets[rnd.Next(0, _streets.Length)],
                    Post = "Секретарь"
                };
                DataContext.Employees.Add(_employee);
            }
            return DataContext;
        }

        public Context CreateDefaultDefendant()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                _defendant = new Defendant
                {
                    FirstName = _firstnames[rnd.Next(0, _firstnames.Length)],
                    SecondName = _secondnames[rnd.Next(0, _secondnames.Length)],
                    LastName = _lastnames[rnd.Next(0, _lastnames.Length)],
                    BirthDay = new DateTime(rnd.Next(1970, 1997), rnd.Next(1, 11), rnd.Next(1, 25)),
                    PasportNum = rnd.Next(44, 55),
                    PasportSeries = rnd.Next(44444, 99999)
                };
                DataContext.Defendants.Add(_defendant);
            }

            return DataContext;
        }

        public Context CreateDefaultPlaintiff()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                
                _plaintiff = new Plaintiff
                {
                    FirstName = _firstnames[rnd.Next(0, _firstnames.Length)],
                    SecondName = _secondnames[rnd.Next(0, _secondnames.Length)],
                    LastName = _lastnames[rnd.Next(0, _lastnames.Length)],
                    BirthDay = new DateTime(rnd.Next(1970, 1997), rnd.Next(1, 11), rnd.Next(1, 25)),
                    PasportNum = rnd.Next(44, 55),
                    PasportSeries = rnd.Next(44444, 99999)
                };
                DataContext.Plaintiffs.Add(_plaintiff);
            }
            return DataContext;
        }

        public Context CreateDefaultProtocol()
        {
            _protocol = new Protocol
            {
                WitnessReadings = "Преступника не видели",
                DefendantReadings = "Я не виновна",
                PlaintiffReadings = "Она виновна"
            };

            DataContext.Protocols.Add(_protocol);
            return DataContext;
        }

        public Context CreateDefaultCaseMaterial()
        {
            _caseMaterial = new CaseMaterial()
            {
                Evidence = "Убийство на Таймс-сквер"
            };
            DataContext = new Context();
            DataContext.CaseMaterials.Add(_caseMaterial);
            return DataContext;
        }

        public Context CreateDefaultCourtCase()
        {
            _courtCase = new CourtCase
            {
                StartDateTime = new DateTime(2000, 5, 20),
                EndDateTime = new DateTime(2000, 8, 14),
                Decision = "Оправдать"
            };            
            DataContext = new Context();
            DataContext.CourtCases.Add(_courtCase);
            return DataContext;
        }
    }
}
