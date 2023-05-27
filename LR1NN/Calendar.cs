using System.Globalization;

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

        public static Calendar operator +(Calendar calendar, IEvent evnt)
        {
            calendar.AddEvent(evnt);
            return calendar;
        }
        public static Calendar operator ++(Calendar calendar)
        {
            if (calendar.events.Count > 0)
            {
                IEvent temp = calendar[0];
                calendar.AddEvent(temp);
            }
            return calendar;
        }

        public IEvent this[int i]
        {
            get { return events[i]; }
        }

        public void AddEvent(IEvent evnt)
        {
            events.Add(evnt);
            SortEvents(events);

            Console.WriteLine("Мероприятие добавлено\n");
        }

        public void EditEvent()
        {
            if (IsEmpty()) return;

            PrintEvents();
            int eventNumber = Validator.InputOption(1, GetEventsCount(),
                "Введите номер мероприятия для редактирования");
            Tuple<string, string, string> info = Misc.InputEventInfo();

            IEvent evnt = events[eventNumber - 1];
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
            if (IsEmpty()) return;

            PrintEvents();
            int eventNumber = Validator.InputOption(1, GetEventsCount(),
                "Введите номер мероприятия для удаления");

            events.RemoveAt(eventNumber - 1);
            Console.WriteLine("Мероприятие удалено\n");
        }

        public void CopyEvent()
        {
            if (IsEmpty()) return;

            PrintEvents();
            int eventNumber = Validator.InputOption(1, GetEventsCount(),
                "Введите номер мероприятия для копирования");
            int copiesAmount = Validator.InputOption(1, 10,
                "Введите количество копий (не более 10)"); ;

            IEvent foundEvent = events[eventNumber - 1];
            IEvent copiedEvent;

            if (foundEvent is OneTimeEvent oneTimeEvent)
            {
                copiedEvent = new OneTimeEvent(oneTimeEvent);
            }
            else
            {
                copiedEvent = new RecurringEvent((RecurringEvent)foundEvent);
            }

            for (int i = 0; i < copiesAmount; i++)
            {
                events.Add(copiedEvent);
            }

            SortEvents(events);
            Console.WriteLine("Мероприятие скопировано\n");
        }

        public bool IsEmpty(bool showMessage = true)
        {
            if (GetEventsCount() == 0)
            {
                if (showMessage)
                {
                    Console.WriteLine("Календарь пуст\n");
                }
                return true;
            }
            return false;
        }

        public int GetEventsCount()
        {
            return events.Count;
        }

        public void PrintEvents()
        {
            if (IsEmpty()) return;

            for (int i = 0; i < events.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                events[i].Show();
            }
            Console.WriteLine();
        }

        public void SearchEventByName()
        {
            if (IsEmpty()) return;

            PrintEvents();
            string eventName;
            do
            {
                Console.Write("Введите имя искомого мероприятия: ");
                eventName = Console.ReadLine();

            } while (eventName == "");

            bool found = false;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].GetName() == eventName)
                {
                    if (!found)
                    {
                        Console.WriteLine("Найденные мероприятия:");
                        found = true;
                    }
                    Console.Write($"{i + 1}: ");
                    events[i].Show();
                }
            }

            if (!found)
            {
                Console.WriteLine("Мероприятия с таким именем не найдены");
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
    }
}
