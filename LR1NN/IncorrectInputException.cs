namespace LR1NN
{
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
