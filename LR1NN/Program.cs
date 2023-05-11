using LR1NN;

Calendar calendar = new Calendar();
int option;
string optionRead;

do
{
    Console.WriteLine("1 - Создание разового мероприятия");
    Console.WriteLine("2 - Создание повторяющегося мероприятия");
    Console.WriteLine("3 - Просмотр мероприятий в календаре");
    Console.WriteLine("4 - Добавить мероприятия по умолчанию постфиксным оператором");
    Console.WriteLine("5 - Добавить мероприятия по умолчанию префиксным оператором");
    Console.WriteLine("6 - Сравнение мероприятий по названию");
    Console.WriteLine("0 - Выйти\n");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || option < 0 || option > 6);

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

                } while (!int.TryParse(optionRead, out option) || 
                    option < 1 || option > 2);

                switch (option)
                {
                    case 1:
                        {
                            calendar += new OneTimeEvent();
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = Event.InputInfo();
                            string eventName = info.Item1;
                            string eventPlace = info.Item2;
                            string eventDate = info.Item3;

                            int eventDuration;

                            do
                            {
                                Console.Write("Введите продолжительность " +
                                    "мероприятия в часах (до 12): ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out eventDuration) ||
                                eventDuration < 0 || eventDuration > 12);

                            OneTimeEvent evnt = new OneTimeEvent(
                                eventName, eventPlace, eventDate, eventDuration);
                            calendar += evnt;
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

                } while (!int.TryParse(optionRead, out option) || 
                    option < 1 || option > 2);

                switch (option)
                {
                    case 1:
                        {
                            calendar += new RecurringEvent();
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = Event.InputInfo();
                            string eventName = info.Item1;
                            string eventPlace = info.Item2;
                            string eventDate = info.Item3;

                            string eventFrequency;

                            do
                            {
                                Console.Write("Введите частоту мероприятия " +
                                    "(день, неделя, месяц, год): ");
                                eventFrequency = Console.ReadLine();

                            } while (eventFrequency != "день" &&
                                     eventFrequency != "неделя" &&
                                     eventFrequency != "месяц" &&
                                     eventFrequency != "год");

                            RecurringEvent evnt = new RecurringEvent(
                                eventName, eventPlace, eventDate, eventFrequency);
                            calendar += evnt;
                            break;
                        }
                }
                break;
            }
        case 3:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                calendar.ShowEvents();
                break;
            }
        case 4:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                calendar++;
                break;
            }
        case 5:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                ++calendar;
                break;
            }
        case 6:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                calendar.ShowEvents();

                do
                {
                    Console.Write("Введите номер первого мероприятия для сравнения: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out option) || 
                    option < 1 || option > calendar.GetEventsCount());

                Event evntA = calendar[option - 1];

                do
                {
                    Console.Write("Введите номер второго мероприятия для сравнения: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out option) ||
                    option < 1 || option > calendar.GetEventsCount());

                Event evntB = calendar[option - 1];
                string cmpOperator;

                do
                {
                    Console.Write("Выберите оператор сравнения (>, <, ==): ");
                    cmpOperator = Console.ReadLine();

                } while (cmpOperator != ">" && 
                         cmpOperator != "<" && 
                         cmpOperator != "==");

                bool cmpResult;

                switch (cmpOperator)
                {
                    case ">":
                        cmpResult = evntA > evntB;
                        break;
                    case "<":
                        cmpResult = evntA < evntB;
                        break;
                    default:
                        cmpResult = evntA == evntB;
                        break;
                }

                Console.Write($"Результат сравнения " +
                    $"{evntA.GetName()} {cmpOperator} {evntB.GetName()}: {cmpResult}\n\n");
                break;
            }
    }
} while (option != 0);