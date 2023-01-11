using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;

namespace kalendar
{
    public class menu
    {
        public static void Start()
        {

            Console.WriteLine("Milý Petře, vítejte!");

            Console.WriteLine("Pro zobrazení vašich událostí stiskněte 1)");
            Console.WriteLine("Pro vytvoření nové události stiskněte 2)");


            bool mainMenuRes = true;
            while (mainMenuRes == true)
            {
                int res = ChooseInput();

                switch (res)
                {
                    case 1:
                        DisplayEvents();
                        mainMenuRes = false;
                        break;
                    case 2:
                        write.ValueEvent();
                        mainMenuRes = false;
                        break;
                }
            };
        }
            // Funkce na zobrazení dat z json souboru
            internal static async Task DisplayEvents()
            {
            var filePath = @"../../../events.json";
            var displayEvents = JsonConvert.DeserializeObject(filePath);

            
        }
        
            internal static int ChooseInput()
            {
                string input = "";
                input = Console.ReadLine();


                switch (input.ToLower())
                {
                    case "1":
                        return 1;
                        break;
                    case "2":
                        return 2;
                        break;
                    
                    default: return 3;

                };

            }
        }
    }

