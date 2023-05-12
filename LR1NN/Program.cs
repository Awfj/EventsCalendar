using LR1NN;

Calendar calendar = new Calendar();
int option;
string optionRead;

do
{
    Console.WriteLine("1 - Создание разового мероприятия");
    Console.WriteLine("2 - Создание повторяющегося мероприятия");
    Console.WriteLine("3 - Просмотр мероприятий в календаре");
    Console.WriteLine("4 - Добавить мероприятия по умолчанию " +
        "постфиксным оператором");
    Console.WriteLine("5 - Добавить мероприятия по умолчанию " +
        "префиксным оператором");
    Console.WriteLine("6 - Сравнение мероприятий по названию");
    Console.WriteLine("0 - Выйти\n");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || 
        option < 0 || option > 6);

    Console.Clear();

    switch (option)
    {
        case 1:
            {
                Tuple<string, string, string, int> info = 
                    OneTimeEvent.InputInfo();
                OneTimeEvent evnt = new OneTimeEvent(
                    info.Item1, info.Item2, info.Item3, info.Item4);
                calendar += evnt;
                break;
            }
        case 2:
            {
                Tuple<string, string, string, string> info = 
                    RecurringEvent.InputInfo();
                RecurringEvent evnt = new RecurringEvent(
                    info.Item1, info.Item2, info.Item3, info.Item4);
                calendar += evnt;
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
                string cmpOperator;

                do
                {
                    Console.Write("Выберите оператор сравнения (>, <, ==): ");
                    cmpOperator = Console.ReadLine();

                } while (cmpOperator != ">" &&
                         cmpOperator != "<" &&
                         cmpOperator != "==");

                Console.WriteLine("Выберите мероприятия для сравнения");
                Console.WriteLine("1 - Мероприятия в календаре");
                Console.WriteLine("2 - Разовые мероприятия");
                Console.WriteLine("3 - Повторяющиеся мероприятия\n");

                do
                {
                    Console.Write("Введите число из меню: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out option) || 
                    option < 1 || option > 3);

                switch (option)
                {
                    case 1:
                        {
                            if (calendar.IsEmpty())
                            {
                                Console.WriteLine("Календарь пуст\n");
                                break;
                            }

                            calendar.ShowEvents();

                            do
                            {
                                Console.Write("Введите номер первого " +
                                    "мероприятия для сравнения: ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out option) ||
                    option < 1 || option > calendar.GetEventsCount());

                            Event evntA = calendar[option - 1];

                            do
                            {
                                Console.Write("Введите номер второго " +
                                    "мероприятия для сравнения: ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out option) ||
                                option < 1 || option > calendar.GetEventsCount());

                            Event evntB = calendar[option - 1];

                            bool cmpResult = cmpOperator switch
                            {
                                ">" => evntA > evntB,
                                "<" => evntA < evntB,
                                _ => evntA == evntB,
                            };

                            Console.Write($"Результат сравнения " +
                                $"{evntA.GetName()} {cmpOperator} " +
                                $"{evntB.GetName()}: {cmpResult}\n\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите данные первого " +
                                "мероприятия для сравнения");
                            Tuple<string, string, string, int> info = 
                                OneTimeEvent.InputInfo();
                            OneTimeEvent evntA = new OneTimeEvent(
                                info.Item1, info.Item2, info.Item3, info.Item4);

                            Console.WriteLine("Введите данные второго " +
                                "мероприятия для сравнения");
                            info = OneTimeEvent.InputInfo();
                            OneTimeEvent evntB = new OneTimeEvent(
                                info.Item1, info.Item2, info.Item3, info.Item4);

                            bool cmpResult = cmpOperator switch
                            {
                                ">" => evntA > evntB,
                                "<" => evntA < evntB,
                                _ => evntA == evntB,
                            };

                            Console.Write($"Результат сравнения " +
                                $"{evntA.GetName()} {cmpOperator} " +
                                $"{evntB.GetName()}: {cmpResult}\n\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите данные первого " +
                                "мероприятия для сравнения");
                            Tuple<string, string, string, string> info = 
                                RecurringEvent.InputInfo();
                            RecurringEvent evntA = new RecurringEvent(
                                info.Item1, info.Item2, info.Item3, info.Item4);

                            Console.WriteLine("Введите данные второго " +
                                "мероприятия для сравнения");
                            info = RecurringEvent.InputInfo();
                            RecurringEvent evntB = new RecurringEvent(
                                info.Item1, info.Item2, info.Item3, info.Item4);

                            bool cmpResult = cmpOperator switch
                            {
                                ">" => evntA > evntB,
                                "<" => evntA < evntB,
                                _ => evntA == evntB,
                            };

                            Console.Write($"Результат сравнения " +
                                $"{evntA.GetName()} {cmpOperator} " +
                                $"{evntB.GetName()}: {cmpResult}\n\n");
                            break;
                        }
                }
                break;
            }
    }
} while (option != 0);