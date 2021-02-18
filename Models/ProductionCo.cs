using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Constantin_Mihai_proiect.Models
{
    public class ProductionCo
    {
        public int ID { get; set; }
        public string ProductionCoName { get; set; }
        public ICollection<Movie> Movies { get; set; } //navigation property
    }
}
