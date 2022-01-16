using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mateut_Andreea_Proiect.Models
{
    public class Mouvie
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Mouvie Title")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele regizorului trebuie sa fie de forma 'Prenume Nume'"), Required,
StringLength(50, MinimumLength = 3)]
        public string Regizor { get; set; }

        [Range(1, 300)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal PriceTicket { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int ReleaserID { get; set; }
        public Releaser Releaser { get; set; }

        public ICollection<MouvieCategory> MouvieCategories { get; set; }
    }
}
