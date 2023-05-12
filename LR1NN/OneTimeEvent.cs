namespace LR1NN
{
    public class OneTimeEvent : Event
    {
        private int duration;

        public OneTimeEvent()
        {
            duration = 0;
        }
        public OneTimeEvent(string name, string place, string date, int duration) 
            : base(name, place, date)
        {
            this.duration = duration;
        }

        public static bool operator <(OneTimeEvent a, OneTimeEvent b)
        {
            int cmp = string.Compare(a.GetName(), b.GetName());
            return cmp < 0;
        }
        public static bool operator >(OneTimeEvent a, OneTimeEvent b)
        {
            int cmp = string.Compare(a.GetName(), b.GetName());
            return cmp > 0;
        }
        public static bool operator ==(OneTimeEvent a, OneTimeEvent b)
        {
            return a.GetName().Equals(b.GetName());
        }
        public static bool operator !=(OneTimeEvent a, OneTimeEvent b)
        {
            return a.GetName().Equals(b.GetName()) == false;
        }

        public void SetDuration(int duration)
        {
            this.duration = duration;
        }
        public int GetDuration()
        {
            return duration;
        }

        public override void Show()
        {
            Console.WriteLine($"\tНазвание мероприятия: {GetName()}");
            Console.WriteLine($"\tМесто проведения: {GetPlace()}");
            Console.WriteLine($"\tДата проведения: {GetDate()}");
            Console.WriteLine($"\tПродолжительность мероприятия (часы): {GetDuration()}");
        }

        public static Tuple<string, string, string, int> InputInfo()
        {
            Tuple<string, string, string> eventInfo = Event.InputInfo();

            int duration;
            string input;

            do
            {
                Console.Write("Введите продолжительность " +
                    "мероприятия в часах (до 12): ");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out duration) ||
                    duration < 0 || duration > 12);

            return new Tuple<string, string, string, int>
                (eventInfo.Item1, eventInfo.Item2, eventInfo.Item3, duration);
        }
    }
}
