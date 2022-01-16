using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mateut_Andreea_Proiect.Models
{
    public class Releaser
    {
        public int ID { get; set; }
        public string ReleaserName { get; set; }
        public ICollection<Mouvie> Mouvies { get; set; }
    }
}
