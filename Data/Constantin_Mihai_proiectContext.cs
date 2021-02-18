using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Constantin_Mihai_proiect.Models;

namespace Constantin_Mihai_proiect.Data
{
    public class Constantin_Mihai_proiectContext : DbContext
    {
        public Constantin_Mihai_proiectContext (DbContextOptions<Constantin_Mihai_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<Constantin_Mihai_proiect.Models.Movie> Movie { get; set; }

        public DbSet<Constantin_Mihai_proiect.Models.ProductionCo> ProductionCo { get; set; }

        public DbSet<Constantin_Mihai_proiect.Models.Developer> Developer { get; set; }

        public DbSet<Constantin_Mihai_proiect.Models.Genre> Genre { get; set; }
    }
}
