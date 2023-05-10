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
        public RecurringEvent(string name, string place, string date, string frequency) 
            : base(name, place, date)
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

        public void SetFrequency(string frequency)
        {
            this.frequency = frequency;
        }
        public string GetFrequency()
        {
            return frequency;
        }

        public void Show()
        {
            Console.WriteLine($"\tНазвание мероприятия: {GetName()}");
            Console.WriteLine($"\tМесто проведения: {GetPlace()}");
            Console.WriteLine($"\tДата проведения: {GetDate()}");
            Console.WriteLine($"\tЧастота мероприятия: {GetFrequency()}");
        }
    }
}
