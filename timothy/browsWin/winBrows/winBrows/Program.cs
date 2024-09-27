namespace winBrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = $"C:\\Users\\pw67ehi\\Desktop";
            Console.WriteLine(Directory.GetDirectories(path));
            recur(path);
        }

        public static void recur(string path)
        {
            
        }
    }
}
