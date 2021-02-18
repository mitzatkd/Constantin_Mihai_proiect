using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Constantin_Mihai_proiect.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public string DeveloperName { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; } //navigation property
    }
}
