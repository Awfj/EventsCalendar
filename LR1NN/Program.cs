using LR1NN;
using System.Text.RegularExpressions;

Calendar calendar;
int option;
string optionRead;

Console.WriteLine("Создание календаря");
Console.WriteLine("1 - Конструктор по умолчанию");
Console.WriteLine("2 - Конструктор с параметрами");
Console.WriteLine("3 - Конструктор копирования");
Console.WriteLine("0 - Выйти");

do
{
    Console.Write("Введите число из меню: ");
    optionRead = Console.ReadLine();

} while (!int.TryParse(optionRead, out option) || option < 0 || option > 3);

switch (option)
{
    case 1:
        {
            calendar = new Calendar();
            break;
        }
    case 2:
        {
            calendar = new Calendar(new List<Event>());
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
    Console.WriteLine("1 - Добавление мероприятия");
    Console.WriteLine("2 - Удаление мероприятия");
    Console.WriteLine("3 - Редактирование мероприятия");
    Console.WriteLine("4 - Поиск мероприятия");
    Console.WriteLine("5 - Просмотр мероприятий");
    Console.WriteLine("6 - Копирование мероприятия");
    Console.WriteLine("7 - Демонстрация работы деструкторов");
    Console.WriteLine("0 - Выйти");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || option < 0 || option > 7);

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
                            Event evnt = new Event();
                            calendar.AddEvent(evnt);
                            break;
                        }
                    case 2:
                        {
                            string eventName;

                            do
                            {
                                Console.Write("Введите название мероприятия: ");
                                eventName = Console.ReadLine();

                            } while (eventName == "");

                            string eventPlace;

                            do
                            {
                                Console.Write("Введите место проведения: ");
                                eventPlace = Console.ReadLine();

                            } while (eventPlace == "");

                            string eventDate;
                            bool isEventDateValid;
                            do
                            {
                                Console.Write("Введите дату проведения в формате d.m: ");
                                eventDate = Console.ReadLine();
                                isEventDateValid = Regex.IsMatch(eventDate, Validator.DATE_PATTERN);

                            } while (!(isEventDateValid && Validator.IsDateCorrect(eventDate)));

                            Console.WriteLine("\n1 - Вызов метода Event(Event evnt)");
                            Console.WriteLine("2 - Вызов метода Event(string name, " +
                                "string place, string date)");

                            do
                            {
                                Console.Write("Введите число из меню: ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out option) || option < 1 || option > 2);

                            switch (option)
                            {
                                case 1:
                                    {
                                        calendar.AddEvent(new Event(eventName, eventPlace, eventDate));
                                        break;
                                    }
                                    
                                case 2:
                                    {
                                        calendar.AddEvent(eventName, eventPlace, eventDate);
                                        break;
                                    }   
                            }
                            break;
                        }
                }
                break;
            }
        case 2:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                calendar.ShowEvents();
                int eventNumber;

                do
                {
                    Console.Write("Введите номер мероприятия для удаления: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out eventNumber) || 
                    eventNumber < 1 || 
                    eventNumber > calendar.GetEventsCount());

                calendar.DeleteEvent(eventNumber);
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
                int eventNumber;

                do
                {
                    Console.Write("Введите номер мероприятия для удаления: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out eventNumber) ||
                    eventNumber < 1 ||
                    eventNumber > calendar.GetEventsCount());

                string eventName;

                do
                {
                    Console.Write("Введите новое название мероприятия: ");
                    eventName = Console.ReadLine();

                } while (eventName == "");

                string eventPlace;

                do
                {
                    Console.Write("Введите новое место проведения: ");
                    eventPlace = Console.ReadLine();

                } while (eventPlace == "");

                string eventDate;
                bool isEventDateValid;
                do
                {
                    Console.Write("Введите новую дату проведения в формате d.m: ");
                    eventDate = Console.ReadLine();
                    isEventDateValid = Regex.IsMatch(eventDate, Validator.DATE_PATTERN);

                } while (!(isEventDateValid && Validator.IsDateCorrect(eventDate)));

                calendar.EditEvent(eventNumber, eventName, eventPlace, eventDate);
                break;
            }
        case 4:
            {
                string eventName;

                do
                {
                    Console.Write("Введите имя искомого мероприятия: ");
                    eventName = Console.ReadLine();

                } while (eventName == "");

                calendar.SearchEventByName(eventName);
                break;
            }
        case 5:
            {
                if (calendar.IsEmpty())
                {
                    Console.WriteLine("Календарь пуст\n");
                    break;
                }

                calendar.ShowEvents();
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
                int eventNumber;
                int copyAmount;

                do
                {
                    Console.Write("Введите номер мероприятия для копирования: ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out eventNumber) ||
                    eventNumber < 1 ||
                    eventNumber > calendar.GetEventsCount());

                do
                {
                    Console.Write("Введите количество копий (не более 10): ");
                    optionRead = Console.ReadLine();

                } while (!int.TryParse(optionRead, out copyAmount) || 
                    copyAmount < 1 || 
                    copyAmount > 10);

                calendar.CopyEvent(eventNumber, copyAmount);
                break;
            }
        case 7:
            {
                void CreateObjects()
                {
                    new Calendar();
                    new Event();
                };

                CreateObjects();
                GC.Collect();
                Console.WriteLine();
                break;
            }
    }
} while (option != 0);