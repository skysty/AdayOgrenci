using AdayOgrenci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci.Models
{
    public class HomeViewModel
    {
        public List<Admission> Admissions { get; set; }
        public IEnumerable<AdmissionsModel> Admission { get; set; }
    }
}
