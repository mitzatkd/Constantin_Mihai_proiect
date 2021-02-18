using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Constantin_Mihai_proiect.Data;

namespace Constantin_Mihai_proiect.Models
{
    public class MovieGenresPageModel : PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;
        public void PopulateAssignedGenreData(Constantin_Mihai_proiectContext context,
        Movie movie)
        {
            var allGenres = context.Genre;
            var movieGenres = new HashSet<int>(movie.MovieGenres.Select(g => g.MovieID));
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach (var gen in allGenres)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    GenreID = gen.ID,
                    Name = gen.GenreName,
                    Assigned = movieGenres.Contains(gen.ID)
                });
            }
        }
        public void UpdateMovieGenres(Constantin_Mihai_proiectContext context,
        string[] selectedGenres, Movie movieToUpdate)
        {
            if (selectedGenres == null)
            {
                movieToUpdate.MovieGenres = new List<MovieGenre>();
                return;
            }
            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var movieGenres = new HashSet<int>
            (movieToUpdate.MovieGenres.Select(g => g.Genre.ID));
            foreach (var gen in context.Genre)
            {
                if (selectedGenresHS.Contains(gen.ID.ToString()))
                {
                    if (!movieGenres.Contains(gen.ID))
                    {
                        movieToUpdate.MovieGenres.Add(
                        new MovieGenre
                        {
                            MovieID = movieToUpdate.ID,
                            GenreID = gen.ID
                        });
                    }
                }
                else
                {
                    if (movieGenres.Contains(gen.ID))
                    {
                        MovieGenre movieToRemove
                        = movieToUpdate
                        .MovieGenres
                        .SingleOrDefault(i => i.GenreID == gen.ID);
                        context.Remove(movieToRemove);
                    }
                }
            }
        }
    }
}