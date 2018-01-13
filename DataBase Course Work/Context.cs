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

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourtCase>().Property(c => c.StartDateTime).IsRequired();

            modelBuilder.Entity<CourtCase>().Property(c => c.EndDateTime).IsOptional();

            modelBuilder.Entity<CourtCase>().Property(c => c.Decision).IsOptional();

            modelBuilder.Entity<Employee>().Property(c => c.FirstName).IsRequired();

            modelBuilder.Entity<Employee>().Property(c => c.SecondName).IsRequired();

            modelBuilder.Entity<Employee>().Property(c => c.LastName).IsRequired();

            modelBuilder.Entity<Employee>().Property(c => c.Post).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Employee>().Property(c => c.Location).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Plaintiff>().Property(c => c.FirstName).IsRequired();

            modelBuilder.Entity<Plaintiff>().Property(c => c.SecondName).IsRequired();

            modelBuilder.Entity<Plaintiff>().Property(c => c.LastName).IsRequired();

            modelBuilder.Entity<Plaintiff>().Property(c => c.PasportSeries).IsRequired();

            modelBuilder.Entity<Plaintiff>().Property(c => c.PasportNum).IsRequired();

            modelBuilder.Entity<Defendant>().Property(c => c.FirstName).IsRequired();

            modelBuilder.Entity<Defendant>().Property(c => c.SecondName).IsRequired();

            modelBuilder.Entity<Defendant>().Property(c => c.LastName).IsRequired();

            modelBuilder.Entity<Defendant>().Property(c => c.PasportSeries).IsRequired();

            modelBuilder.Entity<Defendant>().Property(c => c.PasportNum).IsRequired();
        }*/
    }
}
