using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mateut_Andreea_Proiect.Data;
using Mateut_Andreea_Proiect.Models;

namespace Mateut_Andreea_Proiect.Pages.Mouvies
{
    public class DetailsModel : PageModel
    {
        private readonly Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext _context;

        public DetailsModel(Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public Mouvie Mouvie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mouvie = await _context.Mouvie.FirstOrDefaultAsync(m => m.ID == id);

            if (Mouvie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
