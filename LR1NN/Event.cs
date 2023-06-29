namespace LR1NN
{
    public class Event
    {
        public Event()
        {
            DateTime now = DateTime.Now;

            Name = "Unknown";
            Place = "Unknown";
            Date = $"{now.Day}.{now.Month}";
        }

        public Event(string name, string place, string date)
        {
            Name = name;
            Place = place;
            Date = date;
        }
        public Event(Event evnt)
        {
            Name = evnt.Name;
            Place = evnt.Place;
            Date = evnt.Date;
        }

        public string Name { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }

        public string GetInfo()
        {
            return $"\tНазвание мероприятия: {Name}" +
                $"\n\tМесто проведения: {Place}" +
                $"\n\tДата проведения: {Date}";
        }
    }
}
