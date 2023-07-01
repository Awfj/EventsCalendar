using EventsCalendar;
using EventsCalendarLibrary;

Calendar calendar = new();
int option;

Console.WriteLine("КАЛЕНДАРЬ МЕРОПРИЯТИЙ\n");

do
{
    Console.WriteLine("МЕНЮ");
    Console.WriteLine("1 - Добавление мероприятия");
    Console.WriteLine("2 - Изменение мероприятия");
    Console.WriteLine("3 - Удаление мероприятия");
    Console.WriteLine("4 - Поиск мероприятия по названию");
    Console.WriteLine("5 - Просмотр мероприятий");
    Console.WriteLine("0 - Выйти\n");

    option = Misc.InputOption(0, 7);

    switch (option)
    {
        case 1:
            // Добавление мероприятия
            Misc.AddEvent(calendar);
            break;
        case 2:
            // Изменение мероприятия
            Misc.EditEvent(calendar);
            break;
        case 3:
            // Удаление мероприятия
            Misc.DeleteEvent(calendar);
            break;
        case 4:
            // Поиск мероприятия по названию
            Misc.FindEventByName(calendar);
            break;
        case 5:
            // Просмотр мероприятий
            Misc.DisplayEventsWithEmptinessCheck(calendar);
            break;
    }
} while (option != 0);

