using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mateut_Andreea_Proiect.Data;
using Mateut_Andreea_Proiect.Models;

namespace Mateut_Andreea_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext _context;

        public IndexModel(Mateut_Andreea_Proiect.Data.Mateut_Andreea_ProiectContext context)
        {
            this.Category = new List<Category>();
            _context = context;

        }

        public IList<Category> Category { get;set; }

        public MouvieData MouvieD { get; set; }
        public int MouvieID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }

        /* public async Task OnGetAsync(int? id, int? categoryID)
         {
             MouvieD = new MouvieData();

             MouvieD.Mouvies = await _context.Mouvie
             .Include(b => b.Releaser)
             .Include(b => b.MouvieCategories)
             .ThenInclude(b => b.Category)
             .AsNoTracking()
             .OrderBy(b => b.Title)
             .ToListAsync();
             if (id != null)
             {
                 MouvieID = id.Value;
                 Mouvie mouvie = MouvieD.Mouvies
                 .Where(i => i.ID == id.Value).Single();
                 MouvieD.Categories = mouvie.MouvieCategories.Select(s => s.Category);
             }
         }*/
    }
}

