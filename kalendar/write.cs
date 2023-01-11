using System;
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
                Console.WriteLine("Zadej datum a čas: (dd/mm/rrrr)");
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

            Console.WriteLine("\nPro opuštění aplikace stiskni jakoukoliv klávesu");
            Console.ReadLine();

        }
        
    }
}

