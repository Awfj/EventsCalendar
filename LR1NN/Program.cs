using LR1NN;

Calendar calendar;
Misc.InitCalendar(out calendar);
CustomList<IEvent> eventList = new CustomList<IEvent>();
CustomList<int> intList = new CustomList<int>();
CustomList<char> charList = new CustomList<char>();
int option;

Console.WriteLine("\nКалендарь мероприятий 2023");

do
{
    option = Misc.ShowMainMenu();
    Console.Clear();

    switch (option)
    {
        case 1:
            Misc.AddOneTimeEvent(ref calendar, ref eventList);
            break;
        case 2:
            Misc.AddRecurringEvent(ref calendar, ref eventList);
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
            Misc.DemonstrateDestructors();
            break;

        case 9:
            Misc.AddEventPostfix(ref calendar);
            break;
        case 10:
            Misc.AddEventPrefix(ref calendar);
            break;
        case 11:
            Misc.CompareEvents(ref calendar);
            break;

        case 12:
            // Добавление числа в список
            intList.Add(Misc.InputInt());
            break;
        case 13:
            // Добавление символа в список
            charList.Add(Misc.InputChar());
            break;
        case 14:
            // Просмотр списков
            Console.WriteLine("Список мероприятий:");
            eventList.Print();

            Console.WriteLine("Список чисел:");
            intList.Print();

            Console.WriteLine("Список символов:");
            charList.Print();
            break;
        case 15:
            // Сортировка списков
            eventList.Sort();
            intList.Sort();
            charList.Sort();
            Console.WriteLine("Списки отсортированы");
            break;
        case 16:
            // Поиск минимального и максимального элемента
            if (eventList.IsEmpty() == false)
            {
                Console.WriteLine($"Минимальное мероприятие: {eventList.Min()}");
                Console.WriteLine($"Максимальное мероприятие: {eventList.Max()}");
            }

            if (intList.IsEmpty() == false)
            {
                Console.WriteLine($"Минимальное число: {intList.Min()}");
                Console.WriteLine($"Максимальное число: {intList.Max()}");
            }
            try
            {
                Console.WriteLine($"Минимальный символ: {charList.Min()}");
                Console.WriteLine($"Максимальный символ: {charList.Max()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
                
            break;
        case 17:
            // Поиск индекса первого мероприятия в списке
            if (charList.IsEmpty() == false)
            {
                Console.WriteLine(eventList.Find(eventList[0]));
            }
            break;
        case 18:
            // Поиск индекса числа в списке
            Console.WriteLine(intList.Find(Misc.InputInt()));
            break;
        case 19:
            // Поиск индекса символа в списке
            Console.WriteLine(charList.Find(Misc.InputChar()));
            break;
    }
} while (option != 0);