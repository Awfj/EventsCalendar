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

        public static Calendar operator +(Calendar calendar, Event evnt)
        {
            calendar.AddEvent(evnt);
            return calendar;
        }
        public static Calendar operator ++(Calendar calendar)
        {
            if (calendar.events.Count > 0)
            {
                Event temp = calendar[0];
                calendar.AddEvent(temp);
            }
            return calendar;
        }

        public Event this[int index]
        {
            get { return events[index]; }
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
            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(OneTimeEvent evnt)
        {
            events.Add(evnt);
            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(RecurringEvent evnt)
        {
            events.Add(evnt);

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
    }
}
