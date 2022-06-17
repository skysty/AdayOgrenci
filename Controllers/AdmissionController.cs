using AdayOgrenci.Areas.Identity.Data;
using AdayOgrenci.Entity;
using AdayOgrenci.Models;
using AdayOgrenci.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdayOgrenci.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _db;
        private readonly IStudentRepository _repository=null;
        public AdmissionController(UserManager<ApplicationUser> userManager,
            DataContext db,
            IStudentRepository repository)
        {
            _userManager = userManager;
            _db = db;
            _repository = repository; 

        }

        [Authorize(Policy = "UserAccess")]
        [AllowAnonymous]
        public IActionResult Index(string oin)
        {
            var username = _userManager.GetUserName(User);

            var countries = _db.Countries.ToList();
            Admission entity = new Admission();
            if (oin != null)
                entity = _db.Admissions.Where(i => i.OIN == oin).FirstOrDefault(); 
            else
                entity = _db.Admissions.Where(i => i.OIN == username).FirstOrDefault(); 

            if (entity != null)
            {
                var model = new AdmissionViewModel()
                {
                    // Kisisel Bilgiler
                    OIN = entity.OIN,
                    Nation = entity.Nation,
                    PassportNo = entity.PassportNo,
                    FromCountry = entity.FromCountry,
                    City = entity.City,
                    CityType = entity.CityType,
                    District = entity.District,
                    NameEN = entity.NameEN,
                    SurnameEN = entity.SurnameEN,
                    FatherNameEN = entity.FatherNameEN,
                    NameRU = entity.NameRU,
                    SurnameRU = entity.SurnameRU,
                    FatherNameRU = entity.FatherNameRU,
                    Birthday = entity.Birthday,
                    Sex = entity.Sex,
                    Etnicity = entity.Etnicity,
                    //Başvuru Bilgileri
                    RegisterType = entity.RegisterType,
                    GrantNo = entity.GrantNo,
                    GrantType = entity.GrantType,
                    QuotaType = entity.QuotaType,
                    QuotaNo = entity.QuotaNo,
                    FinanceSource = entity.FinanceSource,
                    EducationLanguage = entity.EducationLanguage,
                    ChoiceName = entity.ChoiceName,
                    ChoiceCode = entity.ChoiceCode,
                    Profession = entity.Profession,
                    ProgramDuration = entity.ProgramDuration,
                    ProgramType = entity.ProgramType,
                    EducationType = entity.EducationType,
                    CurriculumNo = entity.CurriculumNo,
                    StudentType = entity.StudentType,
                    //Başvuru Detay
                    AcceptType = entity.AcceptType,
                    Score = entity.Score,
                    CertificateNo = entity.CertificateNo,
                    CertificateDate = entity.CertificateDate,
                    TJK = entity.TJK,
                    LanguageOfExam = entity.LanguageOfExam,
                    ExamOfLesson1 = entity.ExamOfLesson1,
                    ExamOfLesson2 = entity.ExamOfLesson2,
                    ExamOfLesson3 = entity.ExamOfLesson3,
                    ExamOfLesson4 = entity.ExamOfLesson4,
                    ExamOfLesson5 = entity.ExamOfLesson5,
                    ExamOfBranch1 = entity.ExamOfBranch1,
                    ExamOfBranch2 = entity.ExamOfBranch2,
                    //Öğrenim Bilgileri
                    EducateType = entity.EducateType,
                    EducateDescription = entity.EducateDescription,
                    GraduationDocType = entity.GraduationDocType,
                    DocumentDate = entity.DocumentDate,
                    DocumentNo = entity.DocumentNo,
                    GraduationScore = entity.GraduationScore,
                    GraduationDegree = entity.GraduationDegree,
                    ForeignLanguage = entity.ForeignLanguage,
                    PlacementType = entity.PlacementType,
                    GraduationCity = entity.GraduationCity,
                    GraduationDistrict = entity.GraduationDistrict,
                    //Adres Bilgileri
                    Address = entity.Address,
                    AddressType = entity.AddressType,
                    Phone = entity.Phone,
                    PhoneType = entity.PhoneType,
                    Mail = entity.PhoneType,
                    AdressPlacementType = entity.AdressPlacementType,
                    Dorm =entity.Dorm,

                    State = entity.State,
                    Countries = countries
                };
                return View(model);
            }
            var admissionViewModel = new AdmissionViewModel()
            {
                OIN=username,
                Countries = countries
            };
            return View(admissionViewModel);
        }
        
        [HttpPost]
        public IActionResult Index(AdmissionViewModel model, bool state=false)
        {
            if (ModelState.IsValid)
            {
                Admission ctrl = _db.Admissions.Where(i => i.OIN == model.OIN).FirstOrDefault();
                if (ctrl != null)
                {
                    // Kisisel Bilgiler
                    ctrl.OIN = model.OIN;
                    ctrl.Nation = model.Nation;
                    ctrl.PassportNo = model.PassportNo;
                    ctrl.FromCountry = model.FromCountry;
                    ctrl.City = model.City;
                    ctrl.CityType = model.CityType;
                    ctrl.District = model.District;
                    ctrl.NameEN = model.NameEN;
                    ctrl.SurnameEN = model.SurnameEN;
                    ctrl.FatherNameEN = model.FatherNameEN;
                    ctrl.NameRU = model.NameRU;
                    ctrl.SurnameRU = model.SurnameRU;
                    ctrl.FatherNameRU = model.FatherNameRU;
                    ctrl.Birthday = model.Birthday;
                    ctrl.Sex = model.Sex;
                    ctrl.Etnicity = model.Etnicity;
                    //Başvuru Bilgileri
                    ctrl.RegisterType = model.RegisterType;
                    ctrl.GrantNo = model.GrantNo;
                    ctrl.GrantType = model.GrantType;
                    ctrl.QuotaType = model.QuotaType;
                    ctrl.QuotaNo = model.QuotaNo;
                    ctrl.FinanceSource = model.FinanceSource;
                    ctrl.EducationLanguage = model.EducationLanguage;
                    ctrl.ChoiceName = model.ChoiceName;
                    ctrl.ChoiceCode = model.ChoiceCode;
                    ctrl.Profession = model.Profession;
                    ctrl.ProgramDuration = model.ProgramDuration;
                    ctrl.ProgramType = model.ProgramType;
                    ctrl.EducationType = model.EducationType;
                    ctrl.CurriculumNo = model.CurriculumNo;
                    ctrl.StudentType = model.StudentType;
                    //Başvuru Detay
                    ctrl.AcceptType = model.AcceptType;
                    ctrl.Score = model.Score;
                    ctrl.CertificateNo = model.CertificateNo;
                    ctrl.CertificateDate = model.CertificateDate;
                    ctrl.TJK = model.TJK;
                    ctrl.LanguageOfExam = model.LanguageOfExam;
                    ctrl.ExamOfLesson1 = model.ExamOfLesson1;
                    ctrl.ExamOfLesson2 = model.ExamOfLesson2;
                    ctrl.ExamOfLesson3 = model.ExamOfLesson3;
                    ctrl.ExamOfLesson4 = model.ExamOfLesson4;
                    ctrl.ExamOfLesson5 = model.ExamOfLesson5;
                    ctrl.ExamOfBranch1 = model.ExamOfBranch1;
                    ctrl.ExamOfBranch2 = model.ExamOfBranch2;
                    //Öğrenim Bilgileri
                    ctrl.EducateType = model.EducateType;
                    ctrl.EducateDescription = model.EducateDescription;
                    ctrl.GraduationDocType = model.GraduationDocType;
                    ctrl.DocumentDate = model.DocumentDate;
                    ctrl.DocumentNo = model.DocumentNo;
                    ctrl.GraduationScore = model.GraduationScore;
                    ctrl.GraduationDegree = model.GraduationDegree;
                    ctrl.ForeignLanguage = model.ForeignLanguage;
                    ctrl.PlacementType = model.PlacementType;
                    ctrl.GraduationCity = model.GraduationCity;
                    ctrl.GraduationDistrict = model.GraduationDistrict;
                    //Adres Bilgileri
                    ctrl.Address = model.Address;
                    ctrl.AddressType = model.AddressType;
                    ctrl.Phone = model.Phone;
                    ctrl.PhoneType = model.PhoneType;
                    ctrl.Mail = model.PhoneType;
                    ctrl.AdressPlacementType = model.AdressPlacementType;
                    ctrl.Dorm = model.Dorm;

                    if (state)
                    {
                        ctrl.State = true;
                        var count = _db.Admissions.Where(i => i.State == true).Count();
                        var year = DateTime.Now.Year;
                        string contractno = (count + 1).ToString() + "/" + year.ToString();
                        ctrl.ContractNo = contractno;
                        ctrl.WhoAccepted = _userManager.GetUserName(User);
                    }
                        
                    _db.Entry(ctrl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admission", new { oin = ctrl.OIN });
                }
                else
                {
                    var entity = new Admission()
                    {
                        // Kisisel Bilgiler
                        OIN = model.OIN,
                        Nation = model.Nation,
                        PassportNo = model.PassportNo,
                        FromCountry = model.FromCountry,
                        City = model.City,
                        CityType = model.CityType,
                        District = model.District,
                        NameEN = model.NameEN,
                        SurnameEN = model.SurnameEN,
                        FatherNameEN = model.FatherNameEN,
                        NameRU = model.NameRU,
                        SurnameRU = model.SurnameRU,
                        FatherNameRU = model.FatherNameRU,
                        Birthday = model.Birthday,
                        Sex = model.Sex,
                        Etnicity = model.Etnicity,
                        //Başvuru Bilgileri
                        RegisterType = model.RegisterType,
                        GrantNo = model.GrantNo,
                        GrantType = model.GrantType,
                        QuotaType = model.QuotaType,
                        QuotaNo = model.QuotaNo,
                        FinanceSource = model.FinanceSource,
                        EducationLanguage = model.EducationLanguage,
                        ChoiceName = model.ChoiceName,
                        ChoiceCode = model.ChoiceCode,
                        Profession = model.Profession,
                        ProgramDuration = model.ProgramDuration,
                        ProgramType = model.ProgramType,
                        EducationType = model.EducationType,
                        CurriculumNo = model.CurriculumNo,
                        StudentType = model.StudentType,
                        //Başvuru Detay
                        AcceptType = model.AcceptType,
                        Score = model.Score,
                        CertificateNo = model.CertificateNo,
                        CertificateDate = model.CertificateDate,
                        TJK = model.TJK,
                        LanguageOfExam = model.LanguageOfExam,
                        ExamOfLesson1 = model.ExamOfLesson1,
                        ExamOfLesson2 = model.ExamOfLesson2,
                        ExamOfLesson3 = model.ExamOfLesson3,
                        ExamOfLesson4 = model.ExamOfLesson4,
                        ExamOfLesson5 = model.ExamOfLesson5,
                        ExamOfBranch1 = model.ExamOfBranch1,
                        ExamOfBranch2 = model.ExamOfBranch2,
                        //Öğrenim Bilgileri
                        EducateType = model.EducateType,
                        EducateDescription = model.EducateDescription,
                        GraduationDocType = model.GraduationDocType,
                        DocumentDate = model.DocumentDate,
                        DocumentNo = model.DocumentNo,
                        GraduationScore = model.GraduationScore,
                        GraduationDegree = model.GraduationDegree,
                        ForeignLanguage = model.ForeignLanguage,
                        PlacementType = model.PlacementType,
                        GraduationCity = model.GraduationCity,
                        GraduationDistrict = model.GraduationDistrict,
                        //Adres Bilgileri
                        Address = model.Address,
                        AddressType = model.AddressType,
                        Phone = model.Phone,
                        PhoneType = model.PhoneType,
                        Mail = model.PhoneType,
                        AdressPlacementType = model.AdressPlacementType,
                        Dorm = model.Dorm
                    };
                    _db.Admissions.Add(entity);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admission");
                }
            }
            return View();
        }
        public async  Task<ViewResult> Otinish(string? oin) {

            var data = await _repository.GetStundentByOIN(oin);
            
            return View(data);
        }
    }
}
