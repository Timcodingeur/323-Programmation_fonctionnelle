using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ncdu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Veuillez entrer le chemin du dossier : ");
            string path = Console.ReadLine();

            if (Directory.Exists(path))
            {
                DisplayDirectoryContents(path, 3);
            }
            else
            {
                Console.WriteLine("Chemin invalide. Veuillez réessayer.");
            }
        }

        public static void DisplayDirectoryContents(string path, int depth)
        {
            var items = GetDirectoryItems(path, depth);

            if (items.Count == 0)
            {
                Console.WriteLine("Aucun fichier ou dossier trouvé.");
                return;
            }

            long maxSize = items.Max(i => i.Size);
            Console.Clear();
            Console.WriteLine($"Contenu du dossier : {path}\n");

            foreach (var item in items.OrderByDescending(i => i.Size))
            {
                string size = FormatSize(item.Size);
                string bar = new string('#', (int)((item.Size / (double)maxSize) * 20));
                Console.WriteLine($"{size.PadRight(10)} [{bar.PadRight(20)}]  {item.Path}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour quitter.");
            Console.ReadKey();
        }

        public static List<(string Path, long Size)> GetDirectoryItems(string path, int depth, int currentDepth = 0)
        {
            var items = new List<(string Path, long Size)>();

            try
            {
                if (currentDepth < depth)
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        var fileInfo = new FileInfo(file);
                        items.Add((fileInfo.FullName.Replace(path, "").TrimStart(Path.DirectorySeparatorChar), fileInfo.Length));
                    }

                    foreach (var dir in Directory.GetDirectories(path))
                    {
                        var dirInfo = new DirectoryInfo(dir);
                        long dirSize = GetDirectorySize(dirInfo);
                        items.Add((dirInfo.FullName.Replace(path, "").TrimStart(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar, dirSize));
                        items.AddRange(GetDirectoryItems(dir, depth, currentDepth + 1));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur lors de l'accès au chemin : {e.Message}");
            }

            return items;
        }

        public static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            try
            {
                return directoryInfo.GetFiles("*", SearchOption.AllDirectories).Sum(file => file.Length);
            }
            catch
            {
                return 0;
            }
        }

        public static string FormatSize(long size)
        {
            string[] sizes = { "B", "KiB", "MiB", "GiB", "TiB" };
            double formattedSize = size;
            int order = 0;
            while (formattedSize >= 1024 && order < sizes.Length - 1)
            {
                order++;
                formattedSize /= 1024;
            }
            return $"{formattedSize:0.##} {sizes[order]}";
        }
    }
}
