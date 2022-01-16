using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mateut_Andreea_Proiect.Models
{
    public class MouvieCategory
    {
        public int ID { get; set; }
        public int MouvieID { get; set; }
        public Mouvie Mouvie { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
