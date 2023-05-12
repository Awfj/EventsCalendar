namespace LR1NN
{
    public class Calendar
    {
        private List<Event> events = new List<Event>();

        public static Calendar operator +(Calendar calendar, Event evnt)
        {
            calendar.AddEvent(evnt);
            return calendar;
        }
        public static Calendar operator +(Calendar calendar, OneTimeEvent evnt)
        {
            calendar.AddEvent(evnt);
            return calendar;
        }
        public static Calendar operator +(Calendar calendar, RecurringEvent evnt)
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
