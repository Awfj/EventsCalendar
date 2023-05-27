using LR1NN;

Calendar calendar;
Misc.InitCalendar(out calendar);
int option;

Console.WriteLine("\nКалендарь мероприятий 2023");

do
{
    option = Misc.ShowMainMenu();
    Console.Clear();

    switch (option)
    {
        case 1:
            Misc.AddOneTimeEvent(ref calendar);
            break;
        case 2:
            Misc.AddRecurringEvent(ref calendar);
            break;
        case 3:
            calendar.DeleteEvent();
            break;
        case 4:
            calendar.EditEvent();
            break;
        case 5:
            calendar.SearchEventByName();
            break;
        case 6:
            calendar.CopyEvent();
            break;
        case 7:
            calendar.PrintEvents();
            break;
        case 8:
            Misc.AddEventPostfix(ref calendar);
            break;
        case 9:
            Misc.AddEventPrefix(ref calendar);
            break;
        case 10:
            Misc.CompareEvents(ref calendar);
            break;
        case 11:
            Misc.DemonstrateDestructors();
            break;
    }
} while (option != 0);