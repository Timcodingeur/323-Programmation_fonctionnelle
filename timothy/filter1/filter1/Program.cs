namespace filter1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, double> ahe = new Dictionary<string, double>{
                {"e", 12.10},
                {"a", 7.11},
                {"i", 6.59},
                {"s", 6.51},
                {"n", 6.39},
                {"r", 6.07},
                {"t", 5.92},
                {"o", 5.02},
                {"l", 4.96},
                {"u", 4.49},
                {"d", 3.67},
                {"c", 3.18},
                {"m", 2.62},
                {"p", 2.49},
                {"é", 1.94},
                {"g", 1.23},
                {"b", 1.14},
                {"v", 1.11},
                {"h", 1.11},
                {"f", 1.11},
                {"q", 0.65},
                {"y", 0.46},
                {"x", 0.38},
                {"j", 0.34},
                {"è", 0.31},
                {"à", 0.31},
                {"k", 0.29},
                {"w", 0.17},
                {"z", 0.15},
                {"ê", 0.08},
                {"ç", 0.06},
                {"ô", 0.04},
                {"â", 0.03},
                {"î", 0.03},
                {"û", 0.02},
                {"ù", 0.02},
                {"ï", 0.01},
                {"á", 0.01},
                {"ü", 0.01},
                {"ë", 0.01},
                {"ö", 0.01},
                {"í", 0.01}
            };
            string[] bob = new string[] { "bonjours", "luke" };
            bob.ToList().ForEach(Console.WriteLine("réponse.exe is: " +);

            List<double> list = new List<double>();

            foreach (char w in word)
            {
                var proba = ahe[w.ToString()];
                if (list.Contains(w))
                {
                    var index = list.IndexOf(w);
                    list[index] = list[index] / 2;
                }
                else
                {
                    list.Add(w);
                }
            }


        }
    }
}