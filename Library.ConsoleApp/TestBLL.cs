using Library.BLL;
using Library.BLL.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class TestBLL
    {
        public void DisplayAllMoviesOrdered()
        {
            List<Movie> list;

            MovieCollection movies = new MovieCollection();
            movies.GetAll();

            /*list = movies
                .OrderBy(movie => movie.Title)
                .ToList();*/

            list = (from movie in movies
                    orderby movie.Title ascending
                    select movie).ToList();

            Console.WriteLine("******************** TestBLL - DisplayAllMoviesOrdered ********************");
            DisplayMovies(list);
        }

        public void DisplayMoviesBeforeDate(DateTime date)
        {
            List<Movie> list;

            MovieCollection movies = new MovieCollection();
            movies.GetAll();

            /*list = movies
                .OrderBy(movie => movie.Title)
                .ToList();*/

            list = (from movie in movies
                    where movie.Date < date
                    orderby movie.Title ascending
                    select movie).ToList();

            Console.WriteLine("******************** TestBLL - DisplayMoviesBeforeDate ********************");
            DisplayMovies(list);
        }

        public void DisplayMoviesBeforeYear(int year)
        {
            List<Movie> list;

            MovieCollection movies = new MovieCollection();
            movies.GetAll();

            list = (from movie in movies
                    where movie.Date.Year < year
                    orderby movie.Title ascending
                    select movie).ToList();

            Console.WriteLine("******************** TestBLL - DisplayMoviesBeforeYear ********************");
            DisplayMovies(list);
        }

        public void DisplayMoviesByGenreName(string genreName)
        {
            List<Movie> list;

            MovieCollection movies = new MovieCollection();

            movies.GetAll();

            list = (from movie in movies
                    from genre in movie.Genres
                    where genre.Name == genreName
                    orderby movie.Title ascending
                    select movie).ToList();

            Console.WriteLine("******************** TestBLL - DisplayMoviesByGenreName ********************");
            DisplayMovies(list);
        }

        public void DisplayMoviesCountByGenre()
        {
            List<Movie> list;

            GenreCollection genres = new GenreCollection();

            genres.GetAll();

            Console.WriteLine("******************** TestBLL - DisplayMoviesCountByGenre ********************");
            foreach ( Genre genre in genres.OrderBy(g => g.Name))
            {
                MovieCollection movies = new MovieCollection();
                movies.Get_ByGenreId(genre.Id);

                string displayGenre = $"Genre : {genre.Name}, nb movies : {movies.Count}";
            }

            Console.WriteLine();

            var list = (from genre in genres
                        orderby genre.Name ascending
                        select new
                        {
                            genre.Name,
                            genre.Movies.Count
                        }).ToList();


            foreach ( var item in list)
            {
                Console.WriteLine($"Genre :" { item.Name }, )
            }

            DisplayMovies(list);
        }

        private void DisplayMovies(List<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                string displayMovie = string.Format("Title : {0}, date : {1}, nb genres : {2}", movie.Title, movie.Date.ToString(), movie.Genres.Count.ToString());
                //string displayMovie = $"Title : {movie.Title}, date : {movie.Date.ToString()}, nb genres : {movie.Genres.Count.ToString()}";
                Console.WriteLine(displayMovie);

                foreach (Genre genre in movie.Genres.OrderBy(g => g.Name))
                {
                    //string displayGenre = String.Format(" - Genre : {0}", genre.Name);
                    string displayGenre = $" - Genre : {genre.Name}";
                    Console.WriteLine(displayGenre);
                }

                Console.WriteLine();
            }
        }

    }
}
