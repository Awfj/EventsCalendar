using System.Globalization;

namespace LR1NN
{
    public class Calendar
    {
        private List<Event> events = new List<Event>();

        public Calendar()
        {
            Console.WriteLine("Вызван конструктор по умолчанию основного класса");
        }
        public Calendar(List<Event> events)
        {
            Console.WriteLine("Вызван конструктор с параметрами основного класса");
            this.events = events;
        }

        public Calendar(Calendar calendar)
        {
            Console.WriteLine("Вызван конструктор копирования основного класса");
            events = calendar.events;
        }
        ~Calendar()
        {
            Console.WriteLine("Вызван деструктор основного класса");
        }

        public void AddEvent(Event evnt)
        {
            events.Add(evnt);
            SortEvents(events);

            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(OneTimeEvent evnt)
        {
            events.Add(evnt);
            SortEvents(events);

            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(RecurringEvent evnt)
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
        public void AddEvent(string name, string place, string date, int duration)
        {
            events.Add(new OneTimeEvent(name, place, date, duration));
            SortEvents(events);
            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(string name, string place, string date, string frequency)
        {
            events.Add(new RecurringEvent(name, place, date, frequency));
            SortEvents(events);
            Console.WriteLine("Мероприятие добавлено\n");
        }

        public void EditEvent(int eventNumber, string name, string place, string date)
        {
            Event evnt = events[eventNumber - 1];
            evnt.SetName(name);
            evnt.SetPlace(place);
            evnt.SetDate(date);
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
                if (events[i].GetName() == name)
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
                DateTime xDate = DateTime.ParseExact(x.GetDate(), "d.M", CultureInfo.InvariantCulture);
                DateTime yDate = DateTime.ParseExact(y.GetDate(), "d.M", CultureInfo.InvariantCulture);
                int cmp = xDate.CompareTo(yDate);
                if (cmp == 0)
                    cmp = string.Compare(x.GetName(), y.GetName());
                if (cmp == 0)
                    cmp = string.Compare(x.GetPlace(), y.GetPlace());
                return cmp;
            });
        }
    }
}
