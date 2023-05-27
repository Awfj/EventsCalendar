using System.Globalization;
using System.Xml.Linq;

namespace LR1NN
{
    public class Calendar
    {
        private List<IEvent> events = new List<IEvent>();

        public Calendar()
        {
            Console.WriteLine("Вызван конструктор по умолчанию основного класса");
        }
        public Calendar(List<IEvent> events)
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

        public void AddEvent(IEvent evnt)
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

        public void EditEvent()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Календарь пуст\n");
                return;
            }

            PrintEvents();
            int eventNumber = Validator.InputOption(1, GetEventsCount(),
                "Введите номер мероприятия для редактирования");

            IEvent evnt = events[eventNumber - 1];
            Tuple<string, string, string> info = Event.InputInfo();

            evnt.SetName(info.Item1);
            evnt.SetPlace(info.Item2);
            evnt.SetDate(info.Item3);

            if (evnt is OneTimeEvent oneTimeEvent)
            {
                oneTimeEvent.SetDuration(Misc.InputDuration());
            } 
            else if (evnt is RecurringEvent recurringEvent)
            {
                recurringEvent.SetFrequency(Misc.InputFrequency());
            }

            Console.WriteLine("Мероприятие изменено\n");
        }

        public void DeleteEvent()
        {
            if (GetEventsCount() == 0)
            {
                Console.WriteLine("Календарь пуст\n");
                return;
            }

            PrintEvents();
            int eventNumber = Validator.InputOption(1, GetEventsCount(),
                "Введите номер мероприятия для удаления");

            events.RemoveAt(eventNumber - 1);
            Console.WriteLine("Мероприятие удалено\n");
        }

        public void CopyEvent(int eventNumber, int count)
        {
            //Event evnt = new Event((Event)events[eventNumber - 1]);

            for (int i = 0; i < count; i++)
            {
                //events.Add(new Event(evnt));
                events.Add(events[eventNumber - 1]);
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

        public void PrintEvents()
        {
            if (GetEventsCount() == 0)
            {
                Console.WriteLine("Календарь пуст\n");
                return;
            }

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

        private static void SortEvents(List<IEvent> events)
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

        public IEvent this[int i]
        {
            get { return events[i]; }
        }
    }
}
