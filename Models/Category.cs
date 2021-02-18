using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savu_Antonia_Jewelries.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<JewelryCategory> JewelryCategories { get; set; }
    }
}
