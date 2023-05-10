using LR1NN;
using System.Text.RegularExpressions;

List<Event> events = new List<Event>();
List<OneTimeEvent> oneTimeEvents = new List<OneTimeEvent>();
List<RecurringEvent> recurringEvents = new List<RecurringEvent>();

Tuple<string, string, string> InputEventInfo()
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


Calendar calendar;
int option;
string optionRead;

do
{
    Console.WriteLine("1 - Создание мероприятия");
    Console.WriteLine("2 - Создание разового мероприятия");
    Console.WriteLine("3 - Создание повторяющегося мероприятия");
    Console.WriteLine("4 - Просмотр мероприятий");
    Console.WriteLine("5 - Просмотр разовых мероприятий");
    Console.WriteLine("6 - Просмотр повторяющихся мероприятий");
    Console.WriteLine("7 - Демонстрация работы деструкторов и конструкторов копирования");
    Console.WriteLine("0 - Выйти\n");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || option < 0 || option > 9);

    Console.Clear();

    switch (option)
    {
        case 1:
            {
                Console.WriteLine("1 - Конструктор по умолчанию");
                Console.WriteLine("2 - Конструктор с параметрами");

                do
                {
                    Console.Write("Введите число из меню: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out option) || option < 1 || option > 2);

                switch (option)
                {
                    case 1:
                        {
                            Event evnt = new Event();
                            events.Add(evnt);
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = InputEventInfo();
                            string eventName = info.Item1;
                            string eventPlace = info.Item2;
                            string eventDate = info.Item3;

                            events.Add(new Event(eventName, eventPlace, eventDate));
                            break;
                        }
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("1 - Конструктор по умолчанию");
                Console.WriteLine("2 - Конструктор с параметрами");

                do
                {
                    Console.Write("Введите число из меню: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out option) || option < 1 || option > 2);

                switch (option)
                {
                    case 1:
                        {
                            OneTimeEvent evnt = new OneTimeEvent();
                            events.Add(evnt);
                            oneTimeEvents.Add(evnt);
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = InputEventInfo();
                            string eventName = info.Item1;
                            string eventPlace = info.Item2;
                            string eventDate = info.Item3;

                            int eventDuration;

                            do
                            {
                                Console.Write("Введите продолжительность мероприятия в часах (до 12): ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out eventDuration) ||
                            eventDuration < 0 ||
                            eventDuration > 12);

                            OneTimeEvent evnt = new OneTimeEvent(
                                eventName, eventPlace, eventDate, eventDuration);
                            events.Add(evnt);
                            oneTimeEvents.Add(evnt);
                            break;
                        }
                }
                break;
            }
        case 3:
            {
                Console.WriteLine("1 - Конструктор по умолчанию");
                Console.WriteLine("2 - Конструктор с параметрами");

                do
                {
                    Console.Write("Введите число из меню: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out option) || option < 1 || option > 2);

                switch (option)
                {
                    case 1:
                        {
                            RecurringEvent evnt = new RecurringEvent();
                            events.Add(evnt);
                            recurringEvents.Add(evnt);
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = InputEventInfo();
                            string eventName = info.Item1;
                            string eventPlace = info.Item2;
                            string eventDate = info.Item3;

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

                            RecurringEvent evnt = new RecurringEvent(
                                eventName, eventPlace, eventDate, eventFrequency);
                            events.Add(evnt);
                            recurringEvents.Add(evnt);
                            break;
                        }
                }
                break;
            }
        case 4:
            {
                if (events.Count == 0)
                {
                    Console.WriteLine("Нет мероприятий\n");
                    break;
                }

                for (int i = 0; i < events.Count; i++)
                {
                    Console.Write($"{i + 1}: ");
                    events[i].Show();
                }
                Console.WriteLine();
                break;
            }
        case 5:
            {
                if (oneTimeEvents.Count == 0)
                {
                    Console.WriteLine("Нет разовых мероприятий\n");
                    break;
                }

                for (int i = 0; i < oneTimeEvents.Count; i++)
                {
                    Console.Write($"{i + 1}: ");
                    oneTimeEvents[i].Show();
                }
                Console.WriteLine();
                break;
            }
        case 6:
            {
                if (recurringEvents.Count == 0)
                {
                    Console.WriteLine("Нет повторяющихся мероприятий\n");
                    break;
                }

                for (int i = 0; i < recurringEvents.Count; i++)
                {
                    Console.Write($"{i + 1}: ");
                    recurringEvents[i].Show();
                }
                Console.WriteLine();
                break;
            }
        case 7:
            {
                void CreateObjects()
                {
                    new OneTimeEvent(new OneTimeEvent());
                    new RecurringEvent(new RecurringEvent());
                };

                CreateObjects();
                GC.Collect();
                Console.WriteLine();
                break;
            }
    }
} while (option != 0);