namespace LR1NN
{
    public class Event
    {
        private string name;
        private string place;

        public Event()
        {
            Console.WriteLine("Вызван конструктор по умолчанию дополнительного класса");
            name = "Unknown";
            place = "Unknown";
        }
        public Event(string name, string place)
        {
            Console.WriteLine("Вызван конструктор с параметрами дополнительного класса");
            this.name = name;
            this.place = place;
        }
        public Event(Event evnt)
        {
            Console.WriteLine("Вызван конструктор копирования дополнительного класса");
            name = evnt.GetName();
            place = evnt.GetPlace();
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetPlace(string place)
        {
            this.place = place;
        }
        public string GetName()
        {
            return name;
        }
        public string GetPlace()
        {
            return place;
        }
        public void Show()
        {
            Console.WriteLine("\tМероприятие: " + GetName());
            Console.WriteLine("\tМесто проведения: " + GetPlace());
        }
    }
}
