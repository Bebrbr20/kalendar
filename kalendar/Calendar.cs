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
                Console.WriteLine("(K)onec");

                string inpt = Console.ReadLine();
               

                if(inpt == "D" || inpt == "d")
                {
                    weekS += 7;

                    WeekView(weekS);

                   
                }
                else if(inpt == "P" || inpt == "p")
                {
                    weekS -= 7;

                    WeekView(weekS);
                  
                    
                }
                else if(inpt == "k" || inpt == "K")
                {
                    break;
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
    }
}
