using System.Globalization;
using System.Xml.Linq;

namespace LR1NN
{
    public class RecurringEvent : Event
    {
        private string frequency;

        public RecurringEvent()
        {
            Console.WriteLine("Вызван конструктор по умолчанию " +
                "класса-наследника RecurringEvent");
            frequency = "неизвестно";
        }
        public RecurringEvent(string name, string place, 
            string date, string frequency) : base(name, place, date)
        {
            Console.WriteLine("Вызван конструктор с параметрами " +
                "класса-наследника RecurringEvent");
            this.frequency = frequency;
        }
        public RecurringEvent(RecurringEvent evnt) : base(evnt)
        {
            Console.WriteLine("Вызван конструктор копирования " +
                "класса-наследника RecurringEvent");
            frequency = evnt.GetFrequency();
        }
        ~RecurringEvent()
        {
            Console.WriteLine("Вызван деструктор " +
                "класса-наследника RecurringEvent");
        }

        public static bool operator <(RecurringEvent a, RecurringEvent b)
        {
            int cmp = string.Compare(a.GetName(), b.GetName());
            return cmp < 0;
        }
        public static bool operator >(RecurringEvent a, RecurringEvent b)
        {
            int cmp = string.Compare(a.GetName(), b.GetName());
            return cmp > 0;
        }
        public static bool operator ==(RecurringEvent a, RecurringEvent b)
        {
            return a.GetName().Equals(b.GetName());
        }
        public static bool operator !=(RecurringEvent a, RecurringEvent b)
        {
            return a.GetName().Equals(b.GetName()) == false;
        }

        public void SetFrequency(string frequency)
        {
            this.frequency = frequency;
        }
        public string GetFrequency()
        {
            return frequency;
        }

        public override void Show()
        {
            Console.WriteLine($"\tНазвание мероприятия: {GetName()}");
            Console.WriteLine($"\tМесто проведения: {GetPlace()}");
            Console.WriteLine($"\tДата проведения: {GetDate()}");
            Console.WriteLine($"\tЧастота мероприятия: {GetFrequency()}");
        }
    }
}
