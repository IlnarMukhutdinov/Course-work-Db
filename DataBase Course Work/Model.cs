using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataBase_Course_Work
{
    public class CourtCase
    {
        public int CourtCaseId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
        

        public int EmployeeId { get; set; }
        public int ProtocolId { get; set; }
        public int PlaintiffId { get; set; }
        public int CaseMaterialId { get; set; }
        public int DefendantId { get; set; }

        public string Decision { get; set; }

        public Employee Employee { get; set; }
        public Protocol Protocol { get; set; }
        public Plaintiff Plaintiff { get; set; }
        public CaseMaterial CaseMaterial { get; set; }
        public Defendant Defendant { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Location { get; set; }

        public string Post { get; set; }

        public List<CourtCase> CourtCases { get; set; }
    }

    public class CaseMaterial
    {
        public int CaseMaterialId { get; set; }

        public string Evidence { get; set; }

        public List<CourtCase> CourtCases { get; set; }
    }

    public class Protocol
    {
        public int ProtocolId { get; set; }

        public string WitnessReadings { get; set; }

        public string DefendantReadings { get; set; }

        public string PlaintiffReadings { get; set; }

        public List<CourtCase> CourtCases { get; set; }
    }

    public class Plaintiff
    {
        public int PlaintiffId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public int PasportSeries { get; set; }

        public int PasportNum { get; set; }

        public List<CourtCase> CourtCases { get; set; }
    }

    public class Defendant
    {
        public int DefendantId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public int PasportSeries { get; set; }

        public int PasportNum { get; set; }

        public List<CourtCase> CourtCases { get; set; }
    }
}
