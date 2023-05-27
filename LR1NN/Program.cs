using LR1NN;
using System.Text.RegularExpressions;

List<Event> events = new List<Event>();
List<OneTimeEvent> oneTimeEvents = new List<OneTimeEvent>();
List<RecurringEvent> recurringEvents = new List<RecurringEvent>();

Calendar calendar;
int option = Misc.ShowCalendarMenu();

switch (option)
{
    case 1:
        {
            calendar = new Calendar();
            break;
        }
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
    default: return;
}

Console.WriteLine("\nКалендарь мероприятий 2023");

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
                            calendar.AddEvent(evnt);
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = Event.InputInfo();
                            calendar.AddEvent(new Event(info.Item1, info.Item2, info.Item3));
                            break;
                        }
                    case 3:
                        {
                            IEvent foundEvnt = Misc.FindEventToCopy(calendar);
                            calendar.AddEvent(new Event((Event)foundEvnt));
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
                            calendar.AddEvent(evnt);
                            break;
                        }
                    case 2:
                        {
                            Tuple<string, string, string> info = Event.InputInfo();
                            int eventDuration = Misc.InputDuration();

                            OneTimeEvent evnt = new OneTimeEvent(
                                info.Item1, info.Item2, info.Item3, eventDuration);
                            calendar.AddEvent(evnt);
                            break;
                        }
                    case 3:
                        {
                            IEvent foundEvnt = Misc.FindEventToCopy(calendar);
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
                break;
            }
        case 3:
            {
                try
                {
                    option = Misc.ShowConstructorMenu();
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
                                Tuple<string, string, string> info = Event.InputInfo();
                                string eventFrequency = Misc.InputFrequency();

                                RecurringEvent evnt = new RecurringEvent(
                                    info.Item1, info.Item2, info.Item3, eventFrequency);
                                calendar.AddEvent(evnt);
                                break;
                            }
                        case 3:
                            {
                                IEvent foundEvnt = Misc.FindEventToCopy(calendar);
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
                catch { }
                break;
            }
        case 4:
            {
                calendar.DeleteEvent();
                break;
            }
        case 5:
            {
                calendar.EditEvent();
                break;
            }
        case 6:
            {
                calendar.PrintEvents();
                break;
            }
        case 10:
            {
                
                break;
            }
        case 9:
            {
                
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