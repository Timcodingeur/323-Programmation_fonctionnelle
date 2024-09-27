using System;
class M { static char[] b = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 
    static int c = 1, d, s; static void Main() => ((Action)(() => { for (; s == 0; 
        Console.Clear(), Console.WriteLine("J1:X J2:O\n" + (c % 2 == 0 ? "Tour J2" : "Tour J1") + "\n"), Console.WriteLine($"| | \n{b[0]}|{b[1]}|{b[2]}\n_____|_____|_____\n | | \n{b[3]}|{b[4]}|{b[5]}\n_____|_____|_____\n | | \n{b[6]}|{b[7]}|{b[8]}\n | | "), d = int.TryParse(Console.ReadLine(), out d) && d > 0 && d < 10 && b[d - 1] != 'X' && b[d - 1] != 'O' ? d : 0, b[d - 1] = d != 0 ? (c++ % 2 == 0 ? 'O' : 'X') : b[d - 1], s = (b[0] == b[1] && b[1] == b[2]) || (b[3] == b[4] && b[4] == b[5]) || (b[6] == b[7] && b[7] == b[8]) || (b[0] == b[3] && b[3] == b[6]) || (b[1] == b[4] && b[4] == b[7]) || (b[2] == b[5] && b[5] == b[8]) || (b[0] == b[4] && b[4] == b[8]) || (b[2] == b[4] && b[4] == b[6]) ? 1 : Array.Exists(b, x => x >= '1' && x <= '9') ? 0 : -1) ;
        Console.Clear(); Console.WriteLine($"| | \n{b[0]}|{b[1]}|{b[2]}\n_____|_____|_____\n | | \n{b[3]}|{b[4]}|{b[5]}\n_____|_____|_____\n | | \n{b[6]}|{b[7]}|{b[8]}\n | | ");
        Console.WriteLine(s == 1 ? $"Le J{(c % 2) + 1} a gagné!" : "Égalité!"); 
        Console.ReadLine(); 
    }))(); }
