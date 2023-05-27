namespace LR1NN
{
    public static class Misc
    {
        public static int ShowMainMenu()
        {
            Console.WriteLine("1 - Создание мероприятия");
            Console.WriteLine("2 - Создание разового мероприятия");
            Console.WriteLine("3 - Создание повторяющегося мероприятия");
            Console.WriteLine("4 - Удаление мероприятия");
            Console.WriteLine("5 - Редактирование мероприятия");
            Console.WriteLine("6 - Просмотр мероприятий");
            Console.WriteLine("5 - Просмотр разовых мероприятий");
            Console.WriteLine("6 - Просмотр повторяющихся мероприятий");
            Console.WriteLine("7 - Демонстрация работы деструкторов и конструкторов копирования");
            Console.WriteLine("0 - Выйти\n");

            return Validator.InputOption(0, 7);
        }

        public static int ShowCalendarMenu()
        {
            Console.WriteLine("Создание календаря");
            Console.WriteLine("1 - Конструктор по умолчанию");
            Console.WriteLine("2 - Конструктор с параметрами");
            Console.WriteLine("3 - Конструктор копирования");
            Console.WriteLine("0 - Выйти");

            return Validator.InputOption(0, 3);
        }

        public static int ShowConstructorMenu()
        {
            Console.WriteLine("1 - Конструктор по умолчанию");
            Console.WriteLine("2 - Конструктор с параметрами");
            Console.WriteLine("3 - Конструктор копирования");

            return Validator.InputOption(1, 3);
        }

        public static void DeleteEvent()
        {

        }

        public static void PrintEvents<T>(List<T> list) where T : IEvent
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                list[i].Show();
            }
            Console.WriteLine();
        }

        public static int InputDuration()
        {
            return Validator.InputOption(0, 12, 
                "Введите продолжительность мероприятия в часах (до 12)");
        }

        public static string InputFrequency()
        {
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

            return eventFrequency;
        }

        /*public static T FindEventToCopy<T>(List<T> list) where T : IEvent
        {
            PrintEvents(list);
            int index = Validator.InputOption(0, list.Count - 1,
                "Введите индекс элемента для копирования");

            return list[index];
        }*/

        public static IEvent FindEventToCopy(Calendar calendar)
        {
            if (calendar.IsEmpty())
            {
                Console.WriteLine("Нет мероприятий\n");
                throw new Exception();
            }
            
            calendar.PrintEvents();
            int index = Validator.InputOption(1, calendar.GetEventsCount(),
                "Введите номер элемента для копирования") - 1;

            return calendar[index];
        }
    }
}
