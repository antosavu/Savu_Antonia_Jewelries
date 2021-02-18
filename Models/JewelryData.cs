using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savu_Antonia_Jewelries.Models
{
    public class JewelryData
    {
        public IEnumerable<Jewelry> Jewelries { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<JewelryCategory> JewelryCategories { get; set; }
    }
}
