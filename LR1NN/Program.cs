using System.Text.RegularExpressions;
using EventsCalendarLibrary;

Calendar calendar = new();
int option;
string? optionRead;

Console.WriteLine("КАЛЕНДАРЬ МЕРОПРИЯТИЙ\n");

do
{
    Console.WriteLine("МЕНЮ");
    Console.WriteLine("1 - Добавление мероприятия");
    Console.WriteLine("2 - Удаление мероприятия");
    Console.WriteLine("3 - Редактирование мероприятия");
    Console.WriteLine("4 - Поиск мероприятия");
    Console.WriteLine("5 - Просмотр мероприятий");
    Console.WriteLine("0 - Выйти\n");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || option < 0 || option > 7);

    Console.Clear();

    switch (option)
    {
        case 1:
            // Добавление мероприятия
            {
                string? eventName;
                do
                {
                    Console.Write("Введите название мероприятия: ");
                    eventName = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(eventName));

                string? eventPlace;
                do
                {
                    Console.Write("Введите место проведения: ");
                    eventPlace = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(eventPlace));

                string? eventDate;
                do
                {
                    Console.Write("Введите числами дату проведения в формате ДЕНЬ.МЕСЯЦ: ");
                    eventDate = Console.ReadLine();

                } while (string.IsNullOrEmpty(eventDate) 
                || Regex.IsMatch(eventDate, Validator.DATE_PATTERN) == false 
                || Validator.IsDateCorrect(eventDate) == false);

                calendar.AddEvent(eventName, eventPlace, eventDate);
                Console.WriteLine("Мероприятие добавлено!\n");
                break;
            }
        case 2:
            // Удаление мероприятия
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст!\n");
                    break;
                }

                ShowEvents();
                int eventNumber;

                do
                {
                    Console.Write("Введите номер мероприятия для удаления: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out eventNumber) 
                || eventNumber < 1 
                || eventNumber > calendar.GetEventsCount());

                calendar.DeleteEvent(eventNumber);
                Console.WriteLine("Мероприятие удалено!\n");
                break;
            }
        case 3:
            // Редактирование мероприятия
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст!\n");
                    break;
                }

                ShowEvents();
                int eventNumber;

                do
                {
                    Console.Write("Введите номер мероприятия для редактирования: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out eventNumber) ||
                    eventNumber < 1 ||
                    eventNumber > calendar.GetEventsCount());

                string? eventName;

                do
                {
                    Console.Write("Введите новое название мероприятия: ");
                    eventName = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(eventName));

                string? eventPlace;

                do
                {
                    Console.Write("Введите новое место проведения: ");
                    eventPlace = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(eventPlace));

                string? eventDate;
                do
                {
                    Console.Write("Введите числами новую дату проведения в формате ДЕНЬ.МЕСЯЦ: ");
                    eventDate = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(eventDate)
                || Regex.IsMatch(eventDate, Validator.DATE_PATTERN) == false
                || Validator.IsDateCorrect(eventDate) == false);

                calendar.EditEvent(eventNumber, eventName, eventPlace, eventDate);
                Console.WriteLine("Мероприятие изменено!\n");
                break;
            }
        case 4:
            // Поиск мероприятия
            {
                string? eventName;

                do
                {
                    Console.Write("Введите имя искомого мероприятия: ");
                    eventName = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(eventName));

                calendar.SearchEventByName(eventName);
                break;
            }
        case 5:
            // Просмотр мероприятий
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                ShowEvents();
                break;
            }
    }
} while (option != 0);

void ShowEvents()
{
    Console.WriteLine(calendar.GetEventsInfo());
}