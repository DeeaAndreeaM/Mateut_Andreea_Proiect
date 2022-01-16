using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mateut_Andreea_Proiect.Data;

namespace Mateut_Andreea_Proiect.Models
{
    public class MouvieCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Mateut_Andreea_ProiectContext context,
        Mouvie mouvie)
        {
            var allCategories = context.Category;
            var mouvieCategories = new HashSet<int>(
            mouvie.MouvieCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = mouvieCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateMouvieCategories(Mateut_Andreea_ProiectContext context,
        string[] selectedCategories, Mouvie mouvieToUpdate)
        {
            if (selectedCategories == null)
            {
                mouvieToUpdate.MouvieCategories = new List<MouvieCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var mouvieCategories = new HashSet<int>
            (mouvieToUpdate.MouvieCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!mouvieCategories.Contains(cat.ID))
                    {
                        mouvieToUpdate.MouvieCategories.Add(
                        new MouvieCategory
                        {
                            MouvieID = mouvieToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (mouvieCategories.Contains(cat.ID))
                    {
                        MouvieCategory courseToRemove
                        = mouvieToUpdate
                        .MouvieCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
