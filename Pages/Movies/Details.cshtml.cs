using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Constantin_Mihai_proiect.Data;
using Constantin_Mihai_proiect.Models;

namespace Constantin_Mihai_proiect.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext _context;

        public DetailsModel(Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie
                .Include(b => b.ProductionCo)
                .Include(b => b.Developer)
                .Include(b => b.MovieGenres)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
