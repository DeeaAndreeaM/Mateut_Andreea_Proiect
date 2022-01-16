using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mateut_Andreea_Proiect.Models
{
    public class MouvieData
    {
        public IEnumerable<Mouvie> Mouvies { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<MouvieCategory> MouvieCategories { get; set; }

    }
}
