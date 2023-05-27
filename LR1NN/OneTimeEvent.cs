namespace LR1NN
{
    public class OneTimeEvent : Event, IOneTimeEvent
    {
        private int duration;

        public OneTimeEvent()
        {
            Console.WriteLine("Вызван конструктор по умолчанию " +
                "класса-наследника OneTimeEvent");
            duration = 0;
        }
        public OneTimeEvent(string name, string place, string date, int duration) 
            : base(name, place, date)
        {
            Console.WriteLine("Вызван конструктор с параметрами " +
                "класса-наследника OneTimeEvent");
            this.duration = duration;
        }
        public OneTimeEvent(Event evnt) : base(evnt)
        {
            Console.WriteLine("Вызван конструктор копирования " +
                "класса-наследника OneTimeEvent");
            duration = 0;
        }
        public OneTimeEvent(OneTimeEvent evnt) : base(evnt)
        {
            Console.WriteLine("Вызван конструктор копирования " +
                "класса-наследника OneTimeEvent");
            duration = evnt.GetDuration();
        }
        ~OneTimeEvent()
        {
            Console.WriteLine("Вызван деструктор " +
                "класса-наследника OneTimeEvent");
        }

        public void SetDuration(int duration)
        {
            this.duration = duration;
        }
        public int GetDuration()
        {
            return duration;
        }

        public void Show()
        {
            Console.WriteLine($"\tНазвание мероприятия: {GetName()}");
            Console.WriteLine($"\tМесто проведения: {GetPlace()}");
            Console.WriteLine($"\tДата проведения: {GetDate()}");
            Console.WriteLine($"\tПродолжительность мероприятия (часы): {GetDuration()}");
        }
    }
}
