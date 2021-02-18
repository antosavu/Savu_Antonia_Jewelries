using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savu_Antonia_Jewelries.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string MaterialType { get; set; }
        public ICollection<Jewelry> Jewelries { get; set; }
    }
}
