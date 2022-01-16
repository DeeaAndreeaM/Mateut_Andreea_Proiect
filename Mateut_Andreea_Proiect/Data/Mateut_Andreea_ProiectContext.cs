using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mateut_Andreea_Proiect.Models;

namespace Mateut_Andreea_Proiect.Data
{
    public class Mateut_Andreea_ProiectContext : DbContext
    {
        public Mateut_Andreea_ProiectContext (DbContextOptions<Mateut_Andreea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Mateut_Andreea_Proiect.Models.Mouvie> Mouvie { get; set; }

        public DbSet<Mateut_Andreea_Proiect.Models.Releaser> Releaser { get; set; }

        public DbSet<Mateut_Andreea_Proiect.Models.Category> Category { get; set; }
    }
}
