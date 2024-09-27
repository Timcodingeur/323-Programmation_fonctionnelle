using System;
using System.Collections.Generic;
using System.IO;

namespace placedumarché
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string[]> stand = new List<string[]>();
            try
            {
                foreach (var line in File.ReadLines("../../../../../Place_du_marche2.txt"))
                    stand.Add(line.Split('\t'));
            }
            catch (Exception e)
            {
                Console.WriteLine("J'arrive pas a lire:\n" + e.Message);
                return;
            }
            int numberPeches = 0, maxPastek = 0;
            string[] pastekKing = null;
            foreach (var words in stand)
            {
                if (words[2] == "Pêches") numberPeches++;
                if (words[2] == "Pastèques" && int.TryParse(words[3], out int quantity) && quantity > maxPastek)
                {
                    maxPastek = quantity;
                    pastekKing = words;
                }
            }
            Console.WriteLine($"Le nombre de pêche king est: {numberPeches}");
            Console.WriteLine("Le pastek king est: stand " + (pastekKing == null ? "aucun" : string.Join(" ", pastekKing)));
        }
    }
}
