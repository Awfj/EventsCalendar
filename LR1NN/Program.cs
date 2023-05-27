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
            Misc.AddEvent(ref calendar);
            break;
        case 2:
            Misc.AddOneTimeEvent(ref calendar);
            break;
        case 3:
            Misc.AddRecurringEvent(ref calendar);
            break;
        case 4:
            calendar.DeleteEvent();
            break;
        case 5:
            calendar.EditEvent();
            break;
        case 6:
            calendar.SearchEventByName();
            break;
        case 7:
            calendar.CopyEvent();
            break;
        case 8:
            calendar.PrintEvents();
            break;
        case 9:
            Misc.DemonstrateDestructors();
            break;
    }
} while (option != 0);