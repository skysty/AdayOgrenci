using AdayOgrenci.Entity;
using AdayOgrenci.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdayOgrenci.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _db=null;

        public StudentRepository(DataContext context)
        {
                _db = context;
        }
        public async Task<List<AdmissionsModel>> GetStundentByOIN(string oin)
        {
            return await _db.Admissions.Where(a => a.OIN == oin)
                .Select(admis => new AdmissionsModel
                {
                    NameRU = admis.NameRU,
                    SurnameRU = admis.SurnameRU,
                    Address = admis.Address,
                    OIN=admis.OIN,
                    Phone = admis.Phone,
                    Mail = admis.Mail,
                    Nation = admis.Nation,
                    FatherNameRU = admis.FatherNameRU,
                    Birthday = admis.Birthday,
                    Sex = admis.Sex,
                    GrantType = admis.GrantType,
                    TJK = admis.TJK,
                    ExamOfLesson1=admis.ExamOfLesson1,
                    ExamOfLesson2=admis.ExamOfLesson2,
                    ExamOfLesson3=admis.ExamOfLesson3,
                    ExamOfLesson4=admis.ExamOfLesson4,
                    ExamOfLesson5=admis.ExamOfLesson5,
                    GrantNo=admis.GrantNo,
                    Score = admis.Score,
                    CertificateNo =admis.CertificateNo,
                    CertificateDate=admis.CertificateDate,
                    Etnicity = admis.Etnicity,
                    PassportNo = admis.PassportNo
                }).ToListAsync();
        }
    }
}
