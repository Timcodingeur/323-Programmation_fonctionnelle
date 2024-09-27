using Newtonsoft.Json;
using SharpTrooper.Entities;
using System;


namespace SharpTrooper
{
    internal class Program
    {
        static string trelon = "";
        static void Main(string[] args)
        {
            
            using var httpClient = new HttpClient();
            grosfilm(httpClient);
            personneLaPlus(httpClient);
        }

        static async Task grosfilm(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("https://swapi.dev/api/films/");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            List<Film> films = JsonConvert.DeserializeObject<List<Film>>(jsonResponse);

            string longestTitle = "";

            foreach (var film in films)
            {
                if (film.title.Length > longestTitle.Length)
                {
                    longestTitle = film.title;
                }
                
            }
            Console.WriteLine(longestTitle);

        }

        //compteur pour chercher la personne qui est le plus souvent dans les filme
        static async Task personneLaPlusConnu(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("https://swapi.dev/api/films/");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<People> films = JsonConvert.DeserializeObject<List<People>>(jsonResponse);

            films.Max(People => People.films.Count);

        }
    }
}

