namespace LR1NN
{
    public class Calendar
    {
        private List<Event> events = new List<Event>();

        public void AddEvent(Event evnt)
        {
            events.Add(evnt);
            Console.WriteLine("Мероприятие добавлено\n");
        }
        public void AddEvent(string name, string place)
        {
            events.Add(new Event(name, place));
            Console.WriteLine("Мероприятие добавлено\n");
        }

        public void EditEvent(int eventNumber, string name, string place)
        {
            Event evnt = events[eventNumber - 1];
            evnt.SetName(name);
            evnt.SetPlace(place);
            Console.WriteLine("Мероприятие изменено\n");
        }

        public void DeleteEvent(int eventNumber)
        {
            events.RemoveAt(eventNumber - 1);
            Console.WriteLine("Мероприятие удалено\n");
        }

        public List<Event> GetEvents()
        {
            return events;
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
    }
}
