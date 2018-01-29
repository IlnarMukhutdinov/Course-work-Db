using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataBase_Course_Work
{
    public class CourtCase
    {
        [DisplayName("Номер дела")]
        public int CourtCaseId { get; set; }

        [DisplayName("Дата начала рассмотрения")]
        public DateTime StartDateTime { get; set; }

        [DisplayName("Дата окончания рассмотрения")]
        public DateTime EndDateTime { get; set; }

        [DisplayName("Табельный номер сотрудника")]
        public int EmployeeId { get; set; }

        [DisplayName("ID протокола")]
        public int ProtocolId { get; set; }

        [DisplayName("ID потерпевшего")]
        public int PlaintiffId { get; set; }

        [DisplayName("ID Материалов")]
        public int CaseMaterialId { get; set; }

        [DisplayName("ID Подозреваемого")]
        public int DefendantId { get; set; }

        [DisplayName("Решение судьи")]
        public string Decision { get; set; }

        [DesignOnly(true)]
        public Employee Employee { get; set; }

        [DesignOnly(true)]
        public Protocol Protocol { get; set; }

        [DesignOnly(true)]
        public Plaintiff Plaintiff { get; set; }

        [DesignOnly(true)]
        public CaseMaterial CaseMaterial { get; set; }

        [DesignOnly(true)]
        public Defendant Defendant { get; set; }
    }

    public class Employee
    {
        [DisplayName("Табельный номер сотрудника")]
        public int EmployeeId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        [DisplayName("Отчество")]
        public string LastName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        [DisplayName("Место жительства")]
        public string Location { get; set; }

        [DisplayName("Должность")]
        public string Post { get; set; }

        [DesignOnly(true)]
        public List<CourtCase> CourtCases { get; set; }
    }

    public class CaseMaterial
    {
        [DisplayName("ID материалов")]
        public int CaseMaterialId { get; set; }

        [DisplayName("Данные")]
        public string Evidence { get; set; }

        [DesignOnly(true)]
        public List<CourtCase> CourtCases { get; set; }
    }

    public class Protocol
    {
        [DisplayName("ID протокола")]
        public int ProtocolId { get; set; }

        [DisplayName("Показания свидетелей")]
        public string WitnessReadings { get; set; }

        [DisplayName("Показания подозреваемого")]
        public string DefendantReadings { get; set; }

        [DisplayName("Показания потерпевшего")]
        public string PlaintiffReadings { get; set; }

        [DesignOnly(true)]
        public List<CourtCase> CourtCases { get; set; }
    }

    public class Plaintiff
    {
        [DisplayName("ID потерпевшего")]
        public int PlaintiffId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        [DisplayName("Отчество")]
        public string LastName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        [DisplayName("Серия паспорта")]
        public int PasportSeries { get; set; }

        [DisplayName("Номер паспорта")]
        public int PasportNum { get; set; }

        [DesignOnly(true)]
        public List<CourtCase> CourtCases { get; set; }
    }

    public class Defendant
    {
        [DisplayName("ID подозреваемого")]
        public int DefendantId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string SecondName { get; set; }

        [DisplayName("Отчество")]
        public string LastName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime BirthDay { get; set; }

        [DisplayName("Серия паспорта")]
        public int PasportSeries { get; set; }

        [DisplayName("Номер паспорта")]
        public int PasportNum { get; set; }

        [DesignOnly(true)]
        public List<CourtCase> CourtCases { get; set; }
    }
}
