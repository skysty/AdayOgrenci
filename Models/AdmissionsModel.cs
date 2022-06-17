using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci.Models
{
    public class AdmissionsModel
    {
        public int Id { get; set; }
        public bool State { get; set; }
        // Kisisel Bilgiler
        public string Nation { get; set; }
        public string OIN { get; set; }
        public string PassportNo { get; set; }
        public string FromCountry { get; set; }
        public string City { get; set; }
        public string CityType { get; set; }
        public string District { get; set; }
        public string NameEN { get; set; }
        public string SurnameEN { get; set; }
        public string FatherNameEN { get; set; }
        public string NameRU { get; set; }
        public string SurnameRU { get; set; }
        public string FatherNameRU { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }
        public string Etnicity { get; set; }

        //Başvuru Bilgileri

        public string RegisterType { get; set; }
        public string GrantNo { get; set; }
        public string GrantType { get; set; }
        public string QuotaType { get; set; }
        public string QuotaNo { get; set; }
        public string FinanceSource { get; set; }
        public string EducationLanguage { get; set; }
        public string ChoiceName { get; set; }
        public string ChoiceCode { get; set; }
        public string Profession { get; set; }
        public string ProgramDuration { get; set; }
        public string ProgramType { get; set; }
        public string EducationType { get; set; }
        public string CurriculumNo { get; set; }
        public string StudentType { get; set; }

        //Başvuru Detay

        public string AcceptType { get; set; }
        public string Score { get; set; }
        public string CertificateNo { get; set; }
        public string CertificateDate { get; set; }
        public string TJK { get; set; }
        public string LanguageOfExam { get; set; }
        public string ExamOfLesson1 { get; set; }
        public string ExamOfLesson2 { get; set; }
        public string ExamOfLesson3 { get; set; }
        public string ExamOfLesson4 { get; set; }
        public string ExamOfLesson5 { get; set; }
        public string ExamOfBranch1 { get; set; }
        public string ExamOfBranch2 { get; set; }

        //Öğrenim Bilgileri
        public string EducateType { get; set; }
        public string EducateDescription { get; set; }
        public string GraduationDocType { get; set; }
        public string DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public string GraduationScore { get; set; }
        public string GraduationDegree { get; set; }
        public string ForeignLanguage { get; set; }
        public string PlacementType { get; set; }
        public string GraduationCity { get; set; }
        public string GraduationDistrict { get; set; }

        //Adres Bilgileri
        public string Address { get; set; }
        public string AddressType { get; set; }
        public string Phone { get; set; }
        public string PhoneType { get; set; }
        public string Mail { get; set; }
        public string AdressPlacementType { get; set; }
        public bool Dorm { get; set; }
    }
}
