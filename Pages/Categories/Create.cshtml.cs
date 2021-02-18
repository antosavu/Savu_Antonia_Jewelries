using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Savu_Antonia_Jewelries.Data;
using Savu_Antonia_Jewelries.Models;

namespace Savu_Antonia_Jewelries.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext _context;

        public CreateModel(Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
