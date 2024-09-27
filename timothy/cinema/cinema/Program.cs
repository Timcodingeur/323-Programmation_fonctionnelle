
using System.Collections.Generic;

namespace cinema
{
    public class Movie()
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public int Year { get; set; }
        public string[] LanguageOptions { get; set; }
        public string[] StreamingPlatforms { get; set; }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> frenchMovies = new List<Movie>() {
            new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
            new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
            new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
            new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
            new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
            new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
            new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 3, Year = 1999, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
            };

            List<Movie> allMove = frenchMovies.Where(x => x.Genre != "Comédie" && x.Genre != "Drame"&& x.Rating<7&&x.Year<2000&& !x.LanguageOptions.Contains("Français") && !x.StreamingPlatforms.Contains("Netflix")).ToList();

            foreach(Movie movie in allMove)
            {

                Console.WriteLine(movie.Title);
            }
        }
    }
}
