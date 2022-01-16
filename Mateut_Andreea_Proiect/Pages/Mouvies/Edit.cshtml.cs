using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mateut_Andreea_Proiect.Data;
using Mateut_Andreea_Proiect.Models;

namespace Mateut_Andreea_Proiect.Pages.Mouvies
{
    public class EditModel : MouvieCategoriesPageModel
    {
        private readonly Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext _context;

        public EditModel(Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mouvie Mouvie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mouvie = await _context.Mouvie
 .Include(b => b.Releaser)
 .Include(b => b.MouvieCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);


            if (Mouvie == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Mouvie);

            ViewData["ReleaserID"] = new SelectList(_context.Set<Releaser>(), "ID", "ReleaserName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mouvieToUpdate = await _context.Mouvie
            .Include(i => i.Releaser)
            .Include(i => i.MouvieCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (mouvieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Mouvie>(
            mouvieToUpdate,
            "Mouvie",
            i => i.Title, i => i.Regizor,
            i => i.PriceTicket, i => i.ReleaseDate, i => i.Releaser))
            {
                UpdateMouvieCategories(_context, selectedCategories, mouvieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateMouvieCategories pentru a aplica informatiile din checkboxuri la entitatea Mouvies care
            //este editata
            UpdateMouvieCategories(_context, selectedCategories, mouvieToUpdate);
            PopulateAssignedCategoryData(_context, mouvieToUpdate);
            return Page();
        }

        private bool MouvieExists(int id)
        {
            return _context.Mouvie.Any(e => e.ID == id);
        }
    }
}
