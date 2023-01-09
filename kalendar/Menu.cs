using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalendar
{
    internal class menu
    {
        static void Main()
        {
          
            Console.WriteLine("Zadej událost:");
            string eventos = Console.ReadLine();
            Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
            string datum = Console.ReadLine();

            WriteEvent(eventos, datum);
            DisplayLeaderboard();

            Console.WriteLine("\nPro opuštění aplikace stiskni jakoukoliv klávesu");
            Console.ReadLine();

        }
        internal static bool WriteEvent(string eventt, string datee)
        {
            string FileName = "../../../events.csv";
            string personDetail = eventt + " " + datee + Environment.NewLine;

            if (!File.Exists(FileName))
            {
                string clientHeader = Environment.NewLine;

                File.WriteAllText(FileName, clientHeader);
            }

            File.AppendAllText(FileName, personDetail);

            return true;
        }

        // Funkce na zobrazení dat z csv souboru
        internal static void DisplayLeaderboard()
        {
            string[] leaderboard = System.IO.File.ReadAllLines(@"../../../leaderboard.csv");
            foreach (string line in leaderboard)
            {
                Console.WriteLine(line);
            }
        }

    }
}
