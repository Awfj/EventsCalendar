using System.Text.RegularExpressions;

namespace LR1NN
{
    public static class Misc
    {
        public static int ShowMainMenu()
        {
            Console.WriteLine("1 - Добавление разового мероприятия");
            Console.WriteLine("2 - Добавление повторяющегося мероприятия");
            Console.WriteLine("3 - Удаление мероприятия");
            Console.WriteLine("4 - Редактирование мероприятия");
            Console.WriteLine("5 - Поиск мероприятия");
            Console.WriteLine("6 - Копирование мероприятия");
            Console.WriteLine("7 - Просмотр мероприятий");
            Console.WriteLine("8 - Демонстрация деструкторов\n");

            Console.WriteLine("9 - Добавление мероприятия по умолчанию " +
                "постфиксным оператором");
            Console.WriteLine("10 - Добавление мероприятия по умолчанию " +
                "префиксным оператором");
            Console.WriteLine("11 - Сравнение мероприятий по названию\n");

            Console.WriteLine("12 - Добавление числа в список");
            Console.WriteLine("13 - Добавление символа в список");
            Console.WriteLine("14 - Просмотр списков");
            Console.WriteLine("15 - Сортировка списков");
            Console.WriteLine("16 - Поиск минимального и максимального элемента");
            Console.WriteLine("17 - Поиск индекса мероприятия в списке");
            Console.WriteLine("18 - Поиск индекса числа в списке");
            Console.WriteLine("19 - Поиск индекса символа в списке");
            Console.WriteLine("0 - Выйти\n");

            return Validator.InputOption(0, 19);
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

        public static void AddOneTimeEvent(ref Calendar calendar, ref CustomList<IEvent> list)
        {
            int option = ShowConstructorMenu();
            switch (option)
            {
                case 1:
                    {
                        OneTimeEvent evnt = new OneTimeEvent();
                        calendar += evnt;
                        list.Add(evnt);
                        break;
                    }
                case 2:
                    {
                        Tuple<string, string, string> info = InputEventInfo();
                        int eventDuration = InputDuration();

                        OneTimeEvent evnt = new OneTimeEvent(
                            info.Item1, info.Item2, info.Item3, eventDuration);
                        calendar += evnt;
                        list.Add(evnt);
                        break;
                    }
                case 3:
                    {
                        if (calendar.IsEmpty()) break;

                        IEvent foundEvnt = FindEventToCopy(calendar);
                        if (foundEvnt is OneTimeEvent oneTimeEvent)
                        {
                            calendar += new OneTimeEvent(oneTimeEvent);
                            list.Add(oneTimeEvent);
                        }
                        else
                        {
                            calendar += new OneTimeEvent((Event)foundEvnt);
                            list.Add((Event)foundEvnt);
                        }
                        break;
                    }
            }
        }

        public static void AddRecurringEvent(ref Calendar calendar, ref CustomList<IEvent> list)
        {
            int option = ShowConstructorMenu();
            switch (option)
            {
                case 1:
                    {
                        RecurringEvent evnt = new RecurringEvent();
                        calendar += evnt;
                        list.Add(evnt);
                        break;
                    }
                case 2:
                    {
                        Tuple<string, string, string> info = InputEventInfo();
                        string eventFrequency = InputFrequency();

                        RecurringEvent evnt = new RecurringEvent(
                            info.Item1, info.Item2, info.Item3, eventFrequency);
                        calendar += evnt;
                        list.Add(evnt);
                        break;
                    }
                case 3:
                    {
                        if (calendar.IsEmpty()) break;

                        IEvent foundEvnt = FindEventToCopy(calendar);
                        if (foundEvnt is RecurringEvent recurringEvent)
                        {
                            calendar += new RecurringEvent(recurringEvent);
                            list.Add(recurringEvent);
                        }
                        else
                        {
                            calendar += new RecurringEvent((Event)foundEvnt);
                            list.Add((Event)foundEvnt);
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

                try
                {
                    if (!isEventDateValid)
                    {
                        throw new InvalidDateException();
                    }
                }
                catch(InvalidDateException ex)
                {
                    Console.Write(ex);
                }

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

        public static void AddEventPostfix(ref Calendar calendar)
        {
            if (calendar.IsEmpty()) return;
            calendar++;
        }

        public static void AddEventPrefix(ref Calendar calendar)
        {
            if (calendar.IsEmpty()) return;
            ++calendar;
        }

        public static void CompareEvents(ref Calendar calendar)
        {
            Console.Write("Выберите оператор сравнения (>, <, ==): ");
            string cmpOperator = Console.ReadLine();

            try
            {
                if (cmpOperator != ">" && 
                    cmpOperator != "<" && 
                    cmpOperator != "==")
                {
                    throw new IncorrectInputException();
                }
            }
            catch(IncorrectInputException ex)
            {
                Console.WriteLine(ex);
                return;
            }

            if (calendar.IsEmpty()) return;
            calendar.PrintEvents();

            int eventNumber = Validator.InputOption(1, calendar.GetEventsCount(),
                "Введите номер первого мероприятия для сравнения");
            Event evntA = (Event)calendar[eventNumber - 1];

            eventNumber = Validator.InputOption(1, calendar.GetEventsCount(),
                "Введите номер второго мероприятия для сравнения");
            Event evntB = (Event)calendar[eventNumber - 1];

            bool cmpResult = cmpOperator switch
            {
                ">" => evntA > evntB,
                "<" => evntA < evntB,
                _ => evntA == evntB,
            };

            Console.Write($"Результат сравнения " +
                $"({evntA.GetName()} {cmpOperator} " +
                $"{evntB.GetName()}): {cmpResult}\n\n");
        }

        public static int InputInt()
        {
            int input = Validator.InputOption(int.MinValue, int.MaxValue,
                "Введите число");
            return input;
        }

        public static char InputChar()
        {
            return Validator.InputСhar();
        }
    }
}