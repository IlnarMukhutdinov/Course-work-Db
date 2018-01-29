using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataBase_Course_Work
{
    public class Context : DbContext
    {
        public Context() : base("CourtCase") { }

        public DbSet<CourtCase> CourtCases { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<CaseMaterial> CaseMaterials { get; set; }

        public DbSet<Protocol> Protocols { get; set; }

        public DbSet<Plaintiff> Plaintiffs { get; set; }

        public DbSet<Defendant> Defendants { get; set; }
    }
}
