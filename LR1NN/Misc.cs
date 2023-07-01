using EventsCalendarLibrary;

namespace EventsCalendar
{
    internal class Misc
    {
        /// <summary>
        /// Ввод числа из меню
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int InputOption(int min, int max,
            string message = "Введите число из меню")
        {
            string? optionRead;
            int option;

            do
            {
                Console.Write($"{message}: ");
                optionRead = Console.ReadLine();

            } while (!int.TryParse(optionRead, out option) 
            || option < min 
            || option > max);

            Console.Clear();

            return option;
        }

        /// <summary>
        /// Добавление мероприятия
        /// </summary>
        /// <param name="calendar"></param>
        public static void AddEvent(Calendar calendar)
        {
            calendar.AddEvent(InputEventInfo());
            Console.WriteLine("Мероприятие добавлено!\n");
        }

        /// <summary>
        /// Изменение мероприятия
        /// </summary>
        /// <param name="calendar"></param>
        public static void EditEvent(Calendar calendar)
        {
            if (IsCalendarEmpty(calendar)) return;

            calendar.EditEvent(
                    InputEventNumber(calendar),
                    InputEventInfo());
            Console.WriteLine("Мероприятие изменено!\n");
        }

        /// <summary>
        /// Удаление мероприятия
        /// </summary>
        /// <param name="calendar"></param>
        public static void DeleteEvent(Calendar calendar)
        {
            if (IsCalendarEmpty(calendar)) return;

            calendar.DeleteEvent(InputEventNumber(calendar));
            Console.WriteLine("Мероприятие удалено!\n");
        }

        /// <summary>
        /// Поиск мероприятия по названию
        /// </summary>
        /// <param name="calendar"></param>
        public static void FindEventByName(Calendar calendar)
        {
            string? eventName;

            do
            {
                Console.Write("Введите имя искомого мероприятия: ");
                eventName = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(eventName));

            calendar.SearchEventByName(eventName);
        }

        /// <summary>
        /// Вывод информации о мероприятиях с проверкой на пустоту календаря
        /// </summary>
        /// <param name="calendar"></param>
        public static void DisplayEventsWithEmptinessCheck(Calendar calendar)
        {
            if (IsCalendarEmpty(calendar)) return;
            DisplayEvents(calendar);
        }

        /// <summary>
        /// Вывод информации о мероприятиях
        /// </summary>
        /// <param name="calendar"></param>
        private static void DisplayEvents(Calendar calendar)
        {
            Console.WriteLine(calendar.GetEventsInfo());
        }

        /// <summary>
        /// Ввод информации о мероприятии
        /// </summary>
        /// <returns></returns>
        private static Tuple<string, string, string> InputEventInfo()
        {
            // Название
            string? eventName;
            do
            {
                Console.Write("Введите название мероприятия: ");
                eventName = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(eventName));

            // Место проведения
            string? eventPlace;
            do
            {
                Console.Write("Введите место проведения: ");
                eventPlace = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(eventPlace));

            // Дата проведения
            string? eventDate;
            DateTime date;

            do
            {
                // Дата правильна, если она не раньше текущей и не позже 2100 года
                Console.Write("Введите числами дату проведения в формате МЕСЯЦ ДЕНЬ ГОД: ");
                eventDate = Console.ReadLine();
            }
            while ((DateTime.TryParse(eventDate, out date)
            && date >= DateTime.Today
            && date.Year < 2100) == false);

            return Tuple.Create(eventName, eventPlace, $"{date.Month}/{date.Day}/{date.Year}");
        }

        /// <summary>
        /// Ввод номера мероприятия
        /// </summary>
        /// <param name="calendar"></param>
        /// <returns></returns>
        private static int InputEventNumber(Calendar calendar)
        {
            DisplayEvents(calendar);

            int eventNumber;
            string? optionRead;

            do
            {
                Console.Write("Введите номер мероприятия: ");
                optionRead = Console.ReadLine();

            } while (!int.TryParse(optionRead, out eventNumber) ||
                    eventNumber < 1 ||
                    eventNumber > calendar.GetEventsCount());

            return eventNumber;
        }

        /// <summary>
        /// Проверка на пустоту календаря
        /// </summary>
        /// <param name="calendar"></param>
        /// <returns></returns>
        private static bool IsCalendarEmpty(Calendar calendar)
        {
            if (calendar.IsEmpty())
            {
                Console.WriteLine("Календарь пуст!\n");
                return true;
            }

            return false;
        }
    }
}
