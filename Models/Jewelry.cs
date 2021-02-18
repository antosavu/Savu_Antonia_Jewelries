using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Savu_Antonia_Jewelries.Models
{
    public class Jewelry
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Jewelry Name")]
        public string Product { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        //^ marcheaza inceputul sirului de caractere
        //[A-Z][a-z]+ prenumele -litera mare urmata de oricate litere mici
        //\s spatiu
        //[A-Z][a-z]+ numele- litera mare urmata de oricate litere mici
        //$ marcheaza sfarsitul sirului de caractere

        public string Brand { get; set; }
        [Range(1, 20000)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int MaterialID { get; set; }
        public Material Material { get; set; }

        public ICollection<JewelryCategory> JewelryCategories { get; set; }
    }
}
