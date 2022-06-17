using AdayOgrenci.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci.Models
{
    public class AdmissionViewModel:AdmissionsModel
    {
        public List<Country> Countries { get; set; }
        public IEnumerable<Country> Country { get; set; }
    }
}
