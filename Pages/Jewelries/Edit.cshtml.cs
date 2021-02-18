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

namespace Savu_Antonia_Jewelries.Pages.Jewelries
{
    public class EditModel : JewelryCategoriesPageModel
    {
        private readonly Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext _context;

        public EditModel(Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jewelry Jewelry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jewelry = await _context.Jewelry
                .Include(b => b.Material)
                .Include(b => b.JewelryCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Jewelry == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Jewelry);

            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "MaterialType");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var jewelryToUpdate = await _context.Jewelry
            .Include(i => i.Material)
            .Include(i => i.JewelryCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (jewelryToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Jewelry>(
            jewelryToUpdate,
            "Jewelry",
            i => i.Product, i => i.Brand,
            i => i.Price, i => i.ReleaseDate, i => i.Material))
            {
                UpdateJewelryCategories(_context, selectedCategories, jewelryToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateJewelryCategories(_context, selectedCategories, jewelryToUpdate);
            PopulateAssignedCategoryData(_context, jewelryToUpdate);
            return Page();
        }
    }

}
