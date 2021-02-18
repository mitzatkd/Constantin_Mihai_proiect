using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Constantin_Mihai_proiect.Data;
using Constantin_Mihai_proiect.Models;

namespace Constantin_Mihai_proiect.Pages.Movies
{
    public class CreateModel : MovieGenresPageModel
    {
        private readonly Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext _context;

        public CreateModel(Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProductionCoID"] = new SelectList(_context.Set<ProductionCo>(), "ID", "ProductionCoName");
            ViewData["DeveloperID"] = new SelectList(_context.Set<Developer>(), "ID", "DeveloperName");
            var movie = new Movie();
            movie.MovieGenres = new List<MovieGenre>();
            PopulateAssignedGenreData(_context, movie);

            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            var newMovie = new Movie();
            if (selectedGenres != null)
            {
                newMovie.MovieGenres = new List<MovieGenre>();
                foreach (var gen in selectedGenres)
                {
                    var genToAdd = new MovieGenre
                    {
                        GenreID = int.Parse(gen)
                    };
                    newMovie.MovieGenres.Add(genToAdd);
                }
            }
            if (await TryUpdateModelAsync<Movie>(
            newMovie,
            "Movie",
            i => i.Title, i => i.Director,
            i => i.IMDBRatings, i => i.ReleaseDate, i => i.ProductionCoID, i => i.DeveloperID))
            {
                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedGenreData(_context, newMovie);
            return Page();
        }
    }
}
