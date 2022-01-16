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
    public class IndexModel : PageModel
    {
        private readonly Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext _context;

        public IndexModel(Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Releaser> Releaser { get;set; }

        public async Task OnGetAsync()
        {
            Releaser = await _context.Releaser.ToListAsync();
        }
    }
}
