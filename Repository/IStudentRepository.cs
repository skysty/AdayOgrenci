using AdayOgrenci.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdayOgrenci.Repository
{
    public interface IStudentRepository
    {
        Task<List<AdmissionsModel>> GetStundentByOIN(string oin);
    }
}
