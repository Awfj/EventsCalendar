using LR1NN;

List<Event> events = new List<Event>();
Calendar calendar = new Calendar(); ;

int option;
string optionRead;

do
{
    Console.WriteLine("1 - Создание разового мероприятия");
    Console.WriteLine("2 - Создание повторяющегося мероприятия");
    Console.WriteLine("3 - Просмотр мероприятий в списке");
    Console.WriteLine("4 - Просмотр мероприятий в календаре");
    Console.WriteLine("0 - Выйти\n");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || option < 0 || option > 4);

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
                            OneTimeEvent evnt = new OneTimeEvent();
                            events.Add(evnt);
                            calendar.AddEvent(evnt);
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
                                Console.Write("Введите продолжительность мероприятия в часах (до 12): ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out eventDuration) ||
                            eventDuration < 0 ||
                            eventDuration > 12);

                            OneTimeEvent evnt = new OneTimeEvent(
                                eventName, eventPlace, eventDate, eventDuration);
                            events.Add(evnt);
                            calendar.AddEvent(evnt);
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
                            RecurringEvent evnt = new RecurringEvent();
                            events.Add(evnt);
                            calendar.AddEvent(evnt);
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

                            } while (
                            eventFrequency != "день" &&
                            eventFrequency != "неделя" &&
                            eventFrequency != "месяц" &&
                            eventFrequency != "год");

                            RecurringEvent evnt = new RecurringEvent(
                                eventName, eventPlace, eventDate, eventFrequency);
                            events.Add(evnt);
                            calendar.AddEvent(evnt);
                            break;
                        }
                }
                break;
            }
        case 3:
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
        case 4:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                calendar.ShowEvents();
                break;
            }
    }
} while (option != 0);