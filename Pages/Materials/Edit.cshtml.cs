using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Savu_Antonia_Jewelries.Data;
using Savu_Antonia_Jewelries.Models;

namespace Savu_Antonia_Jewelries.Pages.Materials
{
    public class EditModel : PageModel
    {
        private readonly Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext _context;

        public EditModel(Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Material.FirstOrDefaultAsync(m => m.ID == id);

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(Material.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MaterialExists(int id)
        {
            return _context.Material.Any(e => e.ID == id);
        }
    }
}
