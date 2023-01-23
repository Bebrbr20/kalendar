using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalendar
{
    internal class Calendar
    {
        internal static void Cal()
        {
            int weekS = 0;
            WeekView(weekS);

            while (true)
            {
                Console.WriteLine("\n\n-Nabídka možností-");
                Console.WriteLine("(D)alší týden");
                Console.WriteLine("(P)ředchozí týden");

                Console.WriteLine("\n(N)ová událost");
                Console.WriteLine("(U)pravit událost");
                Console.WriteLine("(S)mazat událost");


                Console.WriteLine("\n(C)asové hledání");

                Console.WriteLine("\n(K)onec");

                string inpt = Console.ReadLine();


                if (inpt == "D" || inpt == "d")
                {
                    weekS += 7;
                    Console.Clear();
                    WeekView(weekS);


                }
                else if (inpt == "P" || inpt == "p")
                {
                    weekS -= 7;
                    Console.Clear();
                    WeekView(weekS);


                }
                else if (inpt == "k" || inpt == "K")
                {
                    break;
                }
                else if (inpt == "n" || inpt == "N")
                {
                    write.ValueEvent();
                    WeekView(weekS);
                }
                else if (inpt == "s" || inpt == "S")
                {
                    Console.Clear();
                    AllView();
                    Console.Write("Vyberte index události ke smazání ->");
                    int res2 = menu.ChooseInt();
                    write.RemoveEvent(res2);
                }
                else if (inpt == "u" || inpt == "U")
                {
                    Console.Clear();
                    AllView();
                    Console.Write("Vyberte index události k upravení ->");
                    int res3 = menu.ChooseInt();
                    write.UpdateEvent(res3);
                    WeekView(weekS);
                }
                else if (inpt == "c" || inpt == "C")
                {
                    Console.Clear();
                    
                    DateOnly datum;
                    while (true)
                    {
                        Console.WriteLine("Zadej datum a čas: (mm/dd/rrrr)");
                        string date = Console.ReadLine();

                        if (DateOnly.TryParse(date, out DateOnly result))
                        {
                            datum = result;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Špatně zadaný formát!");
                        }
                    }
                    readMatchingTime(datum);
                    
                }


            }


        }

        internal static void WeekView(int week)
        {
            int weekEnd = week + 7;
            for (int i = week; i < weekEnd; i++)
            {
                DateTime datetime = DateTime.Today.AddDays(i);
                Console.Write(datetime.DayOfWeek + " ");
                Console.Write(datetime.Day + ".");
                Console.Write(datetime.Month + ". ");
                Console.WriteLine(datetime.Year + " ");

                int index = 1;
                foreach (var item in write.ReadAllEvents())
                {
                    var date = datetime.Date;

                    if (date == item.Date.Date)
                    {

                        Console.Write(" -");
                        Console.Write(item.Title);
                        Console.WriteLine(" " + item.Date.TimeOfDay);

                        index++;
                    }

                }
                if (index == 1) { Console.Write(" -Žádné události \n"); }
            }
        }

        internal static void AllView()
        {
            List<Event> x = write.ReadAllEvents();

            int index = 1;
            foreach (var item in x)
            {
                Console.WriteLine(index + ") " + item.Date.Date + " - " + item.Title);
                index++;
            }

        }

        internal static void readMatchingTime(DateOnly date)
        {
            List<Event> x = write.ReadAllEvents();

            int index = 1;
            foreach (var item in x)
            {
               
                if( date == DateOnly.FromDateTime(item.Date))
                {
                Console.WriteLine(index + ") " + item.Date.Date + " - " + item.Title);
                index++;
                }
                
            }

            Console.WriteLine("Stiskněte jakoukoliv klávesu pro pokračování");
            Console.ReadLine();

            Console.Clear();
        }

    }
}