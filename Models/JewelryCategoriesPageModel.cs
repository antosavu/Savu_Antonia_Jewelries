using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Savu_Antonia_Jewelries.Data;

namespace Savu_Antonia_Jewelries.Models
{
    public class JewelryCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Savu_Antonia_JewelriesContext context,
        Jewelry jewelry)
        {
            var allCategories = context.Category;
            var jewelryCategories = new HashSet<int>(
            jewelry.JewelryCategories.Select(c => c.JewelryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = jewelryCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateJewelryCategories(Savu_Antonia_JewelriesContext context,
        string[] selectedCategories, Jewelry jewelryToUpdate)
        {
            if (selectedCategories == null)
            {
                jewelryToUpdate.JewelryCategories = new List<JewelryCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var jewelryCategories = new HashSet<int>
            (jewelryToUpdate.JewelryCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!jewelryCategories.Contains(cat.ID))
                    {
                        jewelryToUpdate.JewelryCategories.Add(
                        new JewelryCategory
                        {
                            JewelryID = jewelryToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (jewelryCategories.Contains(cat.ID))
                    {
                        JewelryCategory courseToRemove
                        = jewelryToUpdate
                        .JewelryCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
