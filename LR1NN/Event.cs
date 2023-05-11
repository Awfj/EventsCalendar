using System.Text.RegularExpressions;

namespace LR1NN
{
    public abstract class Event
    {
        private string name;
        private string place;
        private string date;

        public Event()
        {
            Console.WriteLine("Вызван конструктор по умолчанию базового класса");
            DateTime now = DateTime.Now;
            name = "неизвестно";
            place = "неизвестно";
            date = $"{now.Day}.{now.Month}";
        }
        public Event(string name, string place, string date)
        {
            Console.WriteLine("Вызван конструктор с параметрами базового класса");
            this.name = name;
            this.place = place;
            this.date = date;
        }
        public Event(Event evnt)
        {
            Console.WriteLine("Вызван конструктор копирования базового класса");
            name = evnt.GetName();
            place = evnt.GetPlace();
            date = evnt.GetDate();
        }
        ~Event()
        {
            Console.WriteLine("Вызван деструктор базового класса");
        }

        public abstract void Show();

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetPlace(string place)
        {
            this.place = place;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }
        public string GetName()
        {
            return name;
        }
        public string GetPlace()
        {
            return place;
        }
        public string GetDate()
        {
            return date;
        }

        public static Tuple<string, string, string> InputInfo()
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

            return new Tuple<string, string, string>(eventName, eventPlace, eventDate);
        }
    }
}
