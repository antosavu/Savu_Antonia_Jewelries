using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savu_Antonia_Jewelries.Models
{
    public class JewelryCategory
    {
        public int ID { get; set; }
        public int JewelryID { get; set; }
        public  Jewelry Jewelry { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
