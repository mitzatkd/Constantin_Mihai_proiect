using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Constantin_Mihai_proiect.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele directorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(100, MinimumLength = 3)]
        //^ marcheaza inceputul sirului de caractere
        //[A-Z][a-z]+ prenumele -litera mare urmata de oricate litere mici
        //\s spatiu
        //[A-Z][a-z]+ numele- litera mare urmata de oricate litere mici
        //$ marcheaza sfarsitul sirului de caractere
        public string Director { get; set; }

        [Range(1, 10)]
        [Column(TypeName = "decimal(3, 1)")]
        public decimal IMDBRatings { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public int ProductionCoID { get; set; }

        public ProductionCo ProductionCo { get; set; }

        public int DeveloperID { get; set; }

        public Developer Developer { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } //navigation property 
    }
}

