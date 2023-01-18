using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace kalendar
{
    public class menu
    {
        public static void Start()
        {

            Console.WriteLine("Milý Petře, vítejte!");

            

            bool mainMenuRes = true;
            while (mainMenuRes == true)
            {

                Console.WriteLine("Zobrazení událostí 1)");
                Console.WriteLine("Vytvoření události 2)");
                Console.WriteLine("Smazání události 3)");
                Console.WriteLine("Upravení události 4)");
                Console.WriteLine("Ukončit 5)");

                int res = ChooseInput();

                switch (res)
                {
                    case 1:

                        Calendar.Cal();
                        

                        Console.ReadLine();

                        break;
                    case 2:
                        write.ValueEvent();
                        
                        break;
                    case 3:
                        write.ReadAllEvents();
                        Console.Write("Vyberte index události ke smazání ->");
                        int res2 = ChooseInt();
                        write.RemoveEvent(res2);
                       
                        break;
                    case 4:
                        write.ReadAllEvents();
                        Console.Write("Vyberte index události k upravení ->");
                        int res3 = ChooseInt();
                        write.UpdateEvent(res3);
                        
                        break;
                    case 0:
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
                case "3":
                    return 3;
                    break;
                case "4":
                    return 4;
                    break;

                default: return 0;

                };


            }

        internal static int ChooseInt()
        {
            int value;
            while (true)
            {
                string input = Console.ReadLine();
              
                if (int.TryParse(input, out value))
                {
                    
                    break;
                }
                
               
            }
            return value;

        }
        }
    }
