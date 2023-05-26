using LR1NN;

List<Event> events = new List<Event>();
List<OneTimeEvent> oneTimeEvents = new List<OneTimeEvent>();
List<RecurringEvent> recurringEvents = new List<RecurringEvent>();

int option;

do
{
    option = Misc.ShowMainMenu();
    Console.Clear();

    switch (option)
    {
        case 1:
            {
                option = Misc.ShowConstructorMenu();
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
                            Tuple<string, string, string> info = Event.InputInfo();
                            events.Add(new Event(info.Item1, info.Item2, info.Item3));
                            break;
                        }
                    case 3:
                        {
                            if (Validator.IsListEmpty(events, "Нет мероприятий"))
                            {
                                break;
                            }

                            Event evnt = new Event(Misc.FindEventToCopy(events));
                            events.Add(evnt);
                            break;
                        }
                }
                break;
            }
        case 2:
            {
                option = Misc.ShowConstructorMenu();
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
                            Tuple<string, string, string> info = Event.InputInfo();
                            int eventDuration = Validator.InputOption(0, 12, 
                                "Введите продолжительность мероприятия в часах (до 12)");

                            OneTimeEvent evnt = new OneTimeEvent(
                                info.Item1, info.Item2, info.Item3, eventDuration);
                            events.Add(evnt);
                            oneTimeEvents.Add(evnt);
                            break;
                        }
                    case 3:
                        {
                            if (Validator.IsListEmpty(oneTimeEvents, "Нет разовых мероприятий"))
                            {
                                break;
                            }

                            OneTimeEvent evnt = new OneTimeEvent(
                                Misc.FindEventToCopy(oneTimeEvents));
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
                option = Validator.InputOption(1, 2);

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
                            Tuple<string, string, string> info = Event.InputInfo();
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
                                info.Item1, info.Item2, info.Item3, eventFrequency);
                            events.Add(evnt);
                            recurringEvents.Add(evnt);
                            break;
                        }
                    case 3:
                        {
                            if (Validator.IsListEmpty(recurringEvents, "Нет повторяющихся мероприятий"))
                            {
                                break;
                            }

                            RecurringEvent evnt = new RecurringEvent(
                                Misc.FindEventToCopy(recurringEvents));
                            recurringEvents.Add(evnt);
                            break;
                        }
                }
                break;
            }
        case 4:
            {
                if (Validator.IsListEmpty(events,
                    "Нет мероприятий"))
                {
                    break;
                }

                Misc.PrintEvents(events);
                break;
            }
        case 5:
            {
                if (Validator.IsListEmpty(oneTimeEvents,
                    "Нет разовых мероприятий"))
                {
                    break;
                }

                Misc.PrintEvents(oneTimeEvents);
                break;
            }
        case 6:
            {
                if (Validator.IsListEmpty(recurringEvents, 
                    "Нет повторяющихся мероприятий")) 
                {
                    break;
                }

                Misc.PrintEvents(recurringEvents);
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