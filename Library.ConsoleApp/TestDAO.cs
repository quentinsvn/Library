using Library.DAO.Context;
using Library.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class TestDAO
    {
        private void DisplayMovies(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                // display movie
                string displayMovie = String.Format("Title : {0}, date : {1}", movie.Title, movie.Date.ToString());
                Console.WriteLine(displayMovie);

                using (LibraryContext context = new LibraryContext())
                {
                    context.Movies.Attach(movie);

                    foreach (Genre genre in movie.Genres.OrderBy(g => g.Name))
                    {
                        string displayGenre = String.Format(" - Genre : {0}", genre.Name);
                        Console.WriteLine(displayGenre);
                    }
                }

                Console.WriteLine();
            }
        }

        public void DisplayAllMoviesOrdered()
        {
            List<Movie> list;

            using (LibraryContext context = new LibraryContext())
            {
                list = context.Movies.OrderBy(m => m.Title).ToList();

                /*
                 var req = from movie in context.movies
                 orderby = movue.Title ascending
                select movie;
                list = req.ToList();
                 */

                Console.WriteLine("******************** TEST DAO - MoviesAlphabetical **************");

            }
            DisplayMovies(list);
        }

        public void DisplayMoviesBeforeDate(DateTime date)
        {
            List<Movie> list;

            using (LibraryContext context = new LibraryContext())
            {
                list = (from movie in context.Movies
                        where movie.Date < date
                        orderby movie.Title ascending
                        select movie).ToList();
            }

            Console.WriteLine("******************** TestBLL - DisplayMoviesBeforeDate ********************");
            DisplayMovies(list);
        }

        public void DisplayMoviesByGenreName(string genreName)
        {
            List<Movie> list;

            using (LibraryContext context = new LibraryContext())
            {
                list = (from movie in context.Movies
                        from genre in movie.Genres
                        where genre.Name == genreName
                        orderby movie.Title ascending
                        select movie).ToList();
            }

            Console.WriteLine("******************** TestBLL - DisplayMoviesByGenreName ********************");
            DisplayMovies(list);
        }

        public void DisplayMoviesCountByGenre()
        {
            using (LibraryContext context = new LibraryContext())
            {
                foreach (Genre genre in context.Genres.OrderBy(g => g.Name))
                {
                    // display genre
                    string displayGenre = $"Genre : {genre.Name}, nb movies : {genre.Movies.Count()}";
                    Console.WriteLine(displayGenre);
                }
            }

            Console.WriteLine("******************** TestBLL - DisplayMoviesCountByGenre ********************");

        }

        public void DisplayMoviesBeforeYear(int year)
        {
            List<Movie> list;

            using (LibraryContext context = new LibraryContext())
            {
                list = (from movie in context.Movies
                        where movie.Date.HasValue &&
                            movie.Date.Value.Year < year
                        orderby movie.Title ascending
                        select movie).ToList();
            }

            Console.WriteLine("******************** TestBLL - DisplayMoviesBeforeYear ********************");
            DisplayMovies(list);
        }
    }
}
