﻿namespace LR1NN
{
    public class CustomList<T>
    {
        private List<T> list;

        public CustomList()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public T this[int index]
        {
            get { return list[index]; }
        }

        public int Find(T item)
        {
            return list.IndexOf(item);
        }

        public T Get(int index)
        {
            return list.ElementAt(index);
        }

        public T Min()
        {
            try
            {
                return list.Min();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public T Max()
        {
            return list.Max();
        }

        // Сортировка по номеру договора
        public void Sort()
        {
            list.Sort();
        }

        public void Print()
        {
            if (IsEmpty()) return;

            foreach (T item in list)
            {
                if (item is Event evnt)
                {
                    evnt.Show();
                }
                else Console.WriteLine(item);
            }
        }
        public int Count()
        {
            return list.Count;
        }

        public bool IsEmpty(bool showMessage = true)
        {
            if (Count() == 0)
            {
                if (showMessage)
                {
                    Console.WriteLine("Список пуст\n");
                }
                return true;
            }
            return false;
        }

    }
}