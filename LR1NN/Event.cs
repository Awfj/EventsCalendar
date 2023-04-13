﻿namespace LR1NN
{
    public class Event
    {
        private string name;
        private string place;
        private string date;

        public Event()
        {
            Console.WriteLine("Вызван конструктор по умолчанию дополнительного класса");
            name = "Unknown";
            place = "Unknown";
            date = "31.12";
        }
        public Event(string name, string place, string date)
        {
            Console.WriteLine("Вызван конструктор с параметрами дополнительного класса");
            this.name = name;
            this.place = place;
            this.date = date;
        }
        public Event(Event evnt)
        {
            Console.WriteLine("Вызван конструктор копирования дополнительного класса");
            name = evnt.GetName();
            place = evnt.GetPlace();
            date = evnt.GetDate();
        }

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
        public void Show()
        {
            Console.WriteLine($"\tНазвание мероприятия: {GetName()}");
            Console.WriteLine($"\tМесто проведения: {GetPlace()}");
            Console.WriteLine($"\tДата проведения: {GetDate()}");
        }
    }
}