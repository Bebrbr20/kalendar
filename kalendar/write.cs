using System;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace kalendar
{
    public class EventList
    {

        public List<Event> data { get; set; }
    }
    public class Event
    {
        public string Title { get; set; }
        public DateOnly Date { get; set; }
    }
    public class write
	{
		public static void ValueEvent()
		{
            Console.WriteLine("Zadej událost:");
            string eventos = Console.ReadLine();
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
            }
            Event events = new Event();
            var filePath = @"../../../events.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var eventlist = JsonConvert.DeserializeObject<List<Event>>(jsonData)
                                  ?? new List<Event>();
            eventlist.Add(new Event()
            { Title = eventos,
              Date = datum
            }) ;

            jsonData = JsonConvert.SerializeObject(eventlist);
            System.IO.File.WriteAllText(filePath, jsonData);


            //WriteEvent(eventos, datum);
            //menu.DisplayEvents();

            Console.WriteLine("\nPro pokračování stiskni jakoukoliv klávesu");
            Console.ReadLine();

        }
        public static void ReadAllEvents()
        {
            Event events = new Event();
            var filePath = @"../../../events.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var eventlist = JsonConvert.DeserializeObject<List<Event>>(jsonData)
            ?? new List<Event>();

            List<Event> SortedList = eventlist.OrderBy(o => o.Date).ToList();
            int index = 1;
            foreach (var item in SortedList)
            {
                Console.Write(index + ")");
                Console.Write(item.Title);
                Console.WriteLine(" "+item.Date);

                index++;
            }

           
           
        }

        public static bool RemoveEvent(int index)
        {
            if (index != null)
            {
                Event events = new Event();
                var filePath = @"../../../events.json";
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var eventlist = JsonConvert.DeserializeObject<List<Event>>(jsonData)
                ?? new List<Event>();

                eventlist.RemoveAt(index-1);

                jsonData = JsonConvert.SerializeObject(eventlist);
                System.IO.File.WriteAllText(filePath, jsonData);

                return true;
            }
            else
            {
                return false;
            }
            
        }


        public static bool UpdateEvent(int index)
        {
            if (index != null)
            {

                DateOnly newdate;
                while (true)
                {
                    Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
                    string date = Console.ReadLine();

                    if (DateOnly.TryParse(date, out DateOnly result))
                    {
                        newdate = result;
                        break;
                    }
                }

                Console.Write("Zadejte název ->");
                string newtitle = Console.ReadLine();

                Event events = new Event();
                var filePath = @"../../../events.json";
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var eventlist = JsonConvert.DeserializeObject<List<Event>>(jsonData)
                ?? new List<Event>();

                eventlist[index - 1].Date = newdate;
                eventlist[index - 1].Title = newtitle;

                jsonData = JsonConvert.SerializeObject(eventlist);
                System.IO.File.WriteAllText(filePath, jsonData);

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

