using System.Collections.Immutable;

namespace immuabl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var players= ImmutableList.Create(
            
                new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Averell", 25)
            );

            Player elder = new ("j", 1);
            
            // search
            foreach (Player p in players)
            {
                if (p.Age > elder.Age) 
                {
                    elder = new Player(p.Name, p.Age);

                }
            }

            Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");

            Console.ReadKey();
        }
        public void execution()
        {

        }
    }

    public class Player
    {
        private readonly string _name;
        private readonly int _age;

        public Player(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name => _name;

        public int Age => _age;
    }

}

