namespace LR1NN
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
