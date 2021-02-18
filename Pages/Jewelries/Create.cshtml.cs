using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Savu_Antonia_Jewelries.Data;
using Savu_Antonia_Jewelries.Models;

namespace Savu_Antonia_Jewelries.Pages.Jewelries
{
    public class CreateModel : JewelryCategoriesPageModel
    {
        private readonly Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext _context;

        public CreateModel(Savu_Antonia_Jewelries.Data.Savu_Antonia_JewelriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "MaterialType");

            var jewelry = new Jewelry();
            jewelry.JewelryCategories = new List<JewelryCategory>();
            PopulateAssignedCategoryData(_context, jewelry);


            return Page();
        }

        [BindProperty]
        public Jewelry Jewelry { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newJewelry = new Jewelry();
            if (selectedCategories != null)
            {
                newJewelry.JewelryCategories = new List<JewelryCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new JewelryCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newJewelry.JewelryCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Jewelry>(
            newJewelry,
            "Jewelry",
            i => i.Product, i => i.Brand,
            i => i.Price, i => i.ReleaseDate, i => i.MaterialID))
            {
                _context.Jewelry.Add(newJewelry);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newJewelry);
            return Page();
        }

    }
}
