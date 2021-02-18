using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Savu_Antonia_Jewelries.Models;

namespace Savu_Antonia_Jewelries.Data
{
    public class Savu_Antonia_JewelriesContext : DbContext
    {
        public Savu_Antonia_JewelriesContext (DbContextOptions<Savu_Antonia_JewelriesContext> options)
            : base(options)
        {
        }

        public DbSet<Savu_Antonia_Jewelries.Models.Jewelry> Jewelry { get; set; }

        public DbSet<Savu_Antonia_Jewelries.Models.Material> Material { get; set; }

        public DbSet<Savu_Antonia_Jewelries.Models.Category> Category { get; set; }
    }
}
