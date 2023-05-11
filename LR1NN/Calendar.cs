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
