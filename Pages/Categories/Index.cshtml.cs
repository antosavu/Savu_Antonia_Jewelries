using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Savu_Antonia_Jewelries.Data;
using Savu_Antonia_Jewelries.Models;

namespace Savu_Antonia_Jewelries.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext _context;

        public IndexModel(Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
