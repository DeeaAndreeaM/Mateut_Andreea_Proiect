using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mateut_Andreea_Proiect.Data;
using Mateut_Andreea_Proiect.Models;

namespace Mateut_Andreea_Proiect.Pages.Mouvies
{
    public class CreateModel : MouvieCategoriesPageModel
    {
        private readonly Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext _context;

        public CreateModel(Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ReleaserID"] = new SelectList(_context.Set<Releaser>(), "ID", "ReleaserName");

            var mouvie = new Mouvie();
            mouvie.MouvieCategories = new List<MouvieCategory>();
            PopulateAssignedCategoryData(_context, mouvie);

            return Page();
        }

        [BindProperty]
        public Mouvie Mouvie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMouvie = new Mouvie();
            if (selectedCategories != null)
            {
                newMouvie.MouvieCategories = new List<MouvieCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MouvieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newMouvie.MouvieCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Mouvie>(
            newMouvie,
            "Mouvie",
            i => i.Title, i => i.Regizor,
            i => i.PriceTicket, i => i.ReleaseDate, i => i.ReleaserID))
            {
                _context.Mouvie.Add(newMouvie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newMouvie);
            return Page();
        }
    }
}
