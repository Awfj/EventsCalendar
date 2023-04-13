﻿
using LR1NN;

Calendar calendar = new Calendar();
int option;
string optionRead;

do
{
    Console.WriteLine("1 - Добавление мероприятия");
    Console.WriteLine("2 - Удаление мероприятия");
    Console.WriteLine("3 - Редактирование мероприятия");
    Console.WriteLine("4 - Поиск мероприятия");
    Console.WriteLine("5 - Просмотр мероприятий");
    Console.WriteLine("6 - Копирование мероприятия");
    Console.WriteLine("0 - Выйти");

    do
    {
        Console.Write("Введите число из меню: ");
        optionRead = Console.ReadLine();

    } while (!int.TryParse(optionRead, out option) || option < 0 || option > 6);

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
                            string eventPlace;

                            do
                            {
                                Console.Write("Введите название мероприятия: ");
                                eventName = Console.ReadLine();
                            } while (eventName == "");

                            do
                            {
                                Console.Write("Введите место проведения: ");
                                eventPlace = Console.ReadLine();
                            } while (eventPlace == "");

                            Console.WriteLine("\n1 - Вызов метода Event(Event evnt)");
                            Console.WriteLine("2 - Вызов метода Event(string name, string place)");

                            do
                            {
                                Console.Write("Введите число из меню: ");
                                optionRead = Console.ReadLine();

                            } while (!int.TryParse(optionRead, out option) || option < 1 || option > 2);

                            switch (option)
                            {
                                case 1:
                                    {
                                        calendar.AddEvent(new Event(eventName, eventPlace));
                                        break;
                                    }
                                    
                                case 2:
                                    {
                                        calendar.AddEvent(eventName, eventPlace);
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
                string eventPlace;

                do
                {
                    Console.Write("Введите новое название мероприятия: ");
                    eventName = Console.ReadLine();
                } while (eventName == "");

                do
                {
                    Console.Write("Введите новое место проведения: ");
                    eventPlace = Console.ReadLine();
                } while (eventPlace == "");

                calendar.EditEvent(eventNumber, eventName, eventPlace);
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
    }
} while (option != 0);