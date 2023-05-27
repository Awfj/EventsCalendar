using System.Text.RegularExpressions;

namespace LR1NN
{
    public static class Misc
    {
        public static int ShowMainMenu()
        {
            Console.WriteLine("1 - Создание мероприятия");
            Console.WriteLine("2 - Создание разового мероприятия");
            Console.WriteLine("3 - Создание повторяющегося мероприятия");
            Console.WriteLine("4 - Удаление мероприятия");
            Console.WriteLine("5 - Редактирование мероприятия");
            Console.WriteLine("6 - Поиск мероприятия");
            Console.WriteLine("7 - Копирование мероприятия");
            Console.WriteLine("8 - Просмотр мероприятий");
            Console.WriteLine("9 - Демонстрация деструкторов");
            Console.WriteLine("0 - Выйти\n");

            return Validator.InputOption(0, 9);
        }

        public static int ShowCalendarMenu()
        {
            Console.WriteLine("Создание календаря");
            Console.WriteLine("1 - Конструктор по умолчанию");
            Console.WriteLine("2 - Конструктор с параметрами");
            Console.WriteLine("3 - Конструктор копирования");
            Console.WriteLine("0 - Выйти");

            return Validator.InputOption(0, 3);
        }

        public static int ShowConstructorMenu()
        {
            Console.WriteLine("1 - Конструктор по умолчанию");
            Console.WriteLine("2 - Конструктор с параметрами");
            Console.WriteLine("3 - Конструктор копирования");

            return Validator.InputOption(1, 3);
        }

        public static int InputDuration()
        {
            return Validator.InputOption(0, 12, 
                "Введите продолжительность мероприятия в часах (до 12)");
        }

        public static string InputFrequency()
        {
            string eventFrequency;

            do
            {
                Console.Write("Введите частоту мероприятия " +
                    "(день, неделя, месяц, год): ");
                eventFrequency = Console.ReadLine();

            } while (
            eventFrequency != "день" &&
            eventFrequency != "неделя" &&
            eventFrequency != "месяц" &&
            eventFrequency != "год");

            return eventFrequency;
        }

        public static IEvent FindEventToCopy(Calendar calendar)
        {
            calendar.PrintEvents();
            int index = Validator.InputOption(1, calendar.GetEventsCount(),
                "Введите номер элемента для копирования") - 1;

            return calendar[index];
        }

        public static void InitCalendar(out Calendar calendar)
        {
            int option = ShowCalendarMenu();

            switch (option)
            {
                case 2:
                    {
                        calendar = new Calendar(new List<IEvent>());
                        break;
                    }
                case 3:
                    {
                        calendar = new Calendar(new Calendar());
                        break;
                    }
                default:
                    calendar = new Calendar();
                    break;
            }
        }

        public static void AddEvent(ref Calendar calendar)
        {
            int option = ShowConstructorMenu();
            switch (option)
            {
                case 1:
                    {
                        Event evnt = new Event();
                        calendar.AddEvent(evnt);
                        break;
                    }
                case 2:
                    {
                        Tuple<string, string, string> info = InputEventInfo();
                        calendar.AddEvent(new Event(info.Item1, info.Item2, info.Item3));
                        break;
                    }
                case 3:
                    {
                        if (calendar.IsEmpty()) break;

                        IEvent foundEvnt = FindEventToCopy(calendar);
                        calendar.AddEvent(new Event((Event)foundEvnt));
                        break;
                    }
            }
        }

        public static void AddOneTimeEvent(ref Calendar calendar)
        {
            int option = ShowConstructorMenu();
            switch (option)
            {
                case 1:
                    {
                        OneTimeEvent evnt = new OneTimeEvent();
                        calendar.AddEvent(evnt);
                        break;
                    }
                case 2:
                    {
                        Tuple<string, string, string> info = InputEventInfo();
                        int eventDuration = InputDuration();

                        OneTimeEvent evnt = new OneTimeEvent(
                            info.Item1, info.Item2, info.Item3, eventDuration);
                        calendar.AddEvent(evnt);
                        break;
                    }
                case 3:
                    {
                        if (calendar.IsEmpty()) break;

                        IEvent foundEvnt = FindEventToCopy(calendar);
                        if (foundEvnt is not OneTimeEvent)
                        {
                            Event evnt = new Event((Event)foundEvnt);
                            calendar.AddEvent(new OneTimeEvent(evnt));
                        }
                        else
                        {
                            calendar.AddEvent(new OneTimeEvent((OneTimeEvent)foundEvnt));
                        }
                        break;
                    }
            }
        }

        public static void AddRecurringEvent(ref Calendar calendar)
        {
            int option = ShowConstructorMenu();
            switch (option)
            {
                case 1:
                    {
                        RecurringEvent evnt = new RecurringEvent();
                        calendar.AddEvent(evnt);
                        break;
                    }
                case 2:
                    {
                        Tuple<string, string, string> info = InputEventInfo();
                        string eventFrequency = InputFrequency();

                        RecurringEvent evnt = new RecurringEvent(
                            info.Item1, info.Item2, info.Item3, eventFrequency);
                        calendar.AddEvent(evnt);
                        break;
                    }
                case 3:
                    {
                        if (calendar.IsEmpty()) break;

                        IEvent foundEvnt = FindEventToCopy(calendar);
                        if (foundEvnt is not RecurringEvent)
                        {
                            Event evnt = new Event((Event)foundEvnt);
                            calendar.AddEvent(new RecurringEvent(evnt));
                        }
                        else
                        {
                            calendar.AddEvent(new RecurringEvent((RecurringEvent)foundEvnt));
                        }
                        break;
                    }
            }
        }

        public static Tuple<string, string, string> InputEventInfo()
        {
            string eventName;

            do
            {
                Console.Write("Введите название мероприятия: ");
                eventName = Console.ReadLine();

            } while (eventName == "");

            string eventPlace;

            do
            {
                Console.Write("Введите место проведения: ");
                eventPlace = Console.ReadLine();

            } while (eventPlace == "");

            string eventDate;
            bool isEventDateValid;
            do
            {
                Console.Write("Введите дату проведения в формате d.m: ");
                eventDate = Console.ReadLine();
                isEventDateValid = Regex.IsMatch(eventDate, Validator.DATE_PATTERN);

            } while (!(isEventDateValid && Validator.IsDateCorrect(eventDate)));

            return new Tuple<string, string, string>(eventName, eventPlace, eventDate);
        }

        public static void DemonstrateDestructors()
        {
            void CreateObjects()
            {
                new OneTimeEvent();
                new RecurringEvent();
            };

            CreateObjects();
            GC.Collect();
            Console.WriteLine();
        }
    }
}
