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
        public DateTime Date { get; set; }
    }
    public class write
    {
        public static void ValueEvent()
        {
            Console.WriteLine("Zadej název události:");
            string eventos;
            while (true)
            {
                eventos = Console.ReadLine();
                if (eventos != null)
                {
                    break;
                }
            }

            DateTime datum;

            while (true)
            {
                Console.WriteLine("Zadej datum a čas: (mm/dd/rrrr hh:mm)");
                string date = Console.ReadLine();

                if (DateTime.TryParse(date, out DateTime result))
                {
                    datum = result;
                    break;
                }
                else
                {
                    Console.WriteLine("Špatně zadaný formát!");
                }
            }
            Event events = new Event();
            var filePath = @"../../../events.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var eventlist = JsonConvert.DeserializeObject<List<Event>>(jsonData)
                                  ?? new List<Event>();
            eventlist.Add(new Event()
            {
                Title = eventos,
                Date = datum
            });

            jsonData = JsonConvert.SerializeObject(eventlist);
            System.IO.File.WriteAllText(filePath, jsonData);


            //WriteEvent(eventos, datum);
            //menu.DisplayEvents();

            Console.WriteLine("\nPro pokračování stiskni jakoukoliv klávesu");
            Console.ReadLine();

            Console.Clear();

        }
        public static List<Event> ReadAllEvents()
        {
            Event events = new Event();
            var filePath = @"../../../events.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var eventlist = JsonConvert.DeserializeObject<List<Event>>(jsonData)
            ?? new List<Event>();

            List<Event> SortedList = eventlist.OrderBy(o => o.Date).ToList();

            return SortedList;



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

                eventlist.RemoveAt(index - 1);

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

                DateTime newdate;
                while (true)
                {
                    Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
                    string date = Console.ReadLine();

                    if (DateTime.TryParse(date, out DateTime result))
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
