using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Constantin_Mihai_proiect.Data;
using Constantin_Mihai_proiect.Models;

namespace Constantin_Mihai_proiect.Pages.Movies
{
    public class EditModel : MovieGenresPageModel
    {
        private readonly Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext _context;

        public EditModel(Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                .Include(b => b.MovieGenres).ThenInclude(b => b.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedGenreData(_context, Movie);
            ViewData["ProductionCoID"] = new SelectList(_context.Set<ProductionCo>(), "ID", "ProductionCoName");
            ViewData["DeveloperID"] = new SelectList(_context.Set<Developer>(), "ID", "DeveloperName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieToUpdate = await _context.Movie
            .Include(i => i.ProductionCo)
            .Include(i => i.Developer)
            .Include(i => i.MovieGenres)
            .ThenInclude(i => i.Genre)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            
            if (await TryUpdateModelAsync<Movie>(
            movieToUpdate,
            "Movie",
                i => i.Title, i => i.Director,
                i => i.IMDBRatings, i => i.ReleaseDate, i => i.ProductionCoID, i => i.DeveloperID))
            {
                UpdateMovieGenres(_context, selectedGenres, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateMovieGenres pentru a aplica informatiile din checkboxuri la entitatea Movies care //este editata
            UpdateMovieGenres(_context, selectedGenres, movieToUpdate);
            PopulateAssignedGenreData(_context, movieToUpdate);

            return Page();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
