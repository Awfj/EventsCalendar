namespace LR1NN
{
    public static class Misc
    {
        public static int ShowMainMenu()
        {
            Console.WriteLine("1 - Создание мероприятия");
            Console.WriteLine("2 - Создание разового мероприятия");
            Console.WriteLine("3 - Создание повторяющегося мероприятия");
            Console.WriteLine("4 - Просмотр мероприятий");
            Console.WriteLine("5 - Просмотр разовых мероприятий");
            Console.WriteLine("6 - Просмотр повторяющихся мероприятий");
            Console.WriteLine("7 - Демонстрация работы деструкторов и конструкторов копирования");
            Console.WriteLine("0 - Выйти\n");

            return Validator.InputOption(0, 7);
        }

        public static int ShowConstructorMenu()
        {
            Console.WriteLine("1 - Конструктор по умолчанию");
            Console.WriteLine("2 - Конструктор с параметрами");
            Console.WriteLine("3 - Конструктор копирования");

            return Validator.InputOption(1, 3);
        }

        public static void PrintEvents<T>(List<T> list) where T : IEvent
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                list[i].Show();
            }
            Console.WriteLine();
        }

        public static T FindEventToCopy<T>(List<T> list) where T : IEvent
        {
            PrintEvents(list);
            int index = Validator.InputOption(0, list.Count - 1,
                "Введите индекс элемента для копирования");

            return list[index];
        }
    }
}
