using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Savu_Antonia_Jewelries.Data;
using Savu_Antonia_Jewelries.Models;

namespace Savu_Antonia_Jewelries.Pages.Jewelries
{
    public class IndexModel : PageModel
    {
        private readonly Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext _context;

        public IndexModel(Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext context)
        {
            _context = context;
        }

        public IList<Jewelry> Jewelry { get;set; }
        public JewelryData JewelryD { get; set; }
        public int JewelryID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            JewelryD = new JewelryData();

            JewelryD.Jewelries = await _context.Jewelry
            .Include(b => b.Material)
            .Include(b => b.JewelryCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Brand)
            .ToListAsync();
            if (id != null)
            {
                JewelryID = id.Value;
                Jewelry jewelry = JewelryD.Jewelries
                .Where(i => i.ID == id.Value).Single();
                JewelryD.Categories = jewelry.JewelryCategories.Select(s => s.Category);
            }
        }

    }
}
