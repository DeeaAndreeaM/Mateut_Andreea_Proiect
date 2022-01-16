using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mateut_Andreea_Proiect.Data;
using Mateut_Andreea_Proiect.Models;

namespace Mateut_Andreea_Proiect.Pages.Releasers
{
    public class DeleteModel : PageModel
    {
        private readonly Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext _context;

        public DeleteModel(Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Releaser Releaser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Releaser = await _context.Releaser.FirstOrDefaultAsync(m => m.ID == id);

            if (Releaser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Releaser = await _context.Releaser.FindAsync(id);

            if (Releaser != null)
            {
                _context.Releaser.Remove(Releaser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
