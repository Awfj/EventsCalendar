using System.Globalization;
using System.Xml.Linq;

namespace LR1NN
{
    public class RecurringEvent : Event
    {
        private string frequency;

        public RecurringEvent()
        {
            frequency = "неизвестно";
        }
        public RecurringEvent(string name, string place, 
            string date, string frequency) : base(name, place, date)
        {
            this.frequency = frequency;
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

        public static Tuple<string, string, string, string> InputInfo()
        {
            Tuple<string, string, string> eventInfo = Event.InputInfo();
            string frequency;

            do
            {
                Console.Write("Введите частоту мероприятия " +
                    "(день, неделя, месяц, год): ");
                frequency = Console.ReadLine();

            } while (frequency != "день" &&
                     frequency != "неделя" &&
                     frequency != "месяц" &&
                     frequency != "год");

            return new Tuple<string, string, string, string>
                (eventInfo.Item1, eventInfo.Item2, eventInfo.Item3, frequency);
        }
    }
}
