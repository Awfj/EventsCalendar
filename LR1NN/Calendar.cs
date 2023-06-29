using System.Globalization;

namespace LR1NN
{
    public class Calendar
    {
        private List<Event> events = new List<Event>();

        public Calendar()
        {
        }
        public Calendar(List<Event> events)
        {
            this.events = events;
        }

        public Calendar(Calendar calendar)
        {
            events = calendar.events;
        }
        public void AddEvent(Event evnt)
        {
            events.Add(evnt);
            SortEvents(events);

            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(string name, string place, string date)
        {
            events.Add(new Event(name, place, date));
            SortEvents(events);
            Console.WriteLine("Мероприятие добавлено\n");
        }

        public void EditEvent(int eventNumber, string name, string place, string date)
        {
            Event evnt = events[eventNumber - 1];
            evnt.Name = name;
            evnt.Place = place;
            evnt.Date = date;
            Console.WriteLine("Мероприятие изменено\n");
        }

        public void DeleteEvent(int eventNumber)
        {
            events.RemoveAt(eventNumber - 1);
            Console.WriteLine("Мероприятие удалено\n");
        }

        public void CopyEvent(int eventNumber, int count)
        {
            Event evnt = new Event(events[eventNumber - 1]);

            for (int i = 0; i < count; i++)
            {
                events.Add(new Event(evnt));
            }
            Console.WriteLine("Мероприятие скопировано\n");
        }

        public bool IsEmpty()
        {
            return (events.Count == 0);
        }

        public int GetEventsCount()
        {
            return events.Count;
        }

        public void ShowEvents()
        {
            for (int i = 0; i < events.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                events[i].Show();
            }
            Console.WriteLine();
        }

        public void SearchEventByName(string name)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Name == name)
                {
                    Console.Write($"{i + 1}: ");
                    events[i].Show();
                }
            }
            Console.WriteLine();
        }

        private static void SortEvents(List<Event> events)
        {
            events.Sort((x, y) =>
            {
                DateTime xDate = DateTime.ParseExact(x.Date, "d.M", CultureInfo.InvariantCulture);
                DateTime yDate = DateTime.ParseExact(y.Date, "d.M", CultureInfo.InvariantCulture);
                int cmp = xDate.CompareTo(yDate);
                if (cmp == 0)
                    cmp = string.Compare(x.Name, y.Name);
                if (cmp == 0)
                    cmp = string.Compare(x.Place, y.Place);
                return cmp;
            });
        }
    }
}
