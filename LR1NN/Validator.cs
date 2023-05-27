namespace LR1NN
{
    public static class Validator
    {
        public const string DATE_PATTERN = @"^(0?[1-9]|[12]\d|3[01])\.(0?[1-9]|1[012])$";

        public static bool IsDateCorrect(string input)
        {
            if (DateTime.TryParse(input, out DateTime date))
            {
                return date >= DateTime.Today;
            }

            return false;
        }

        public static int InputOption(int min, int max, 
            string message = "Введите число из меню")
        {
            string optionRead;
            int option;

            do
            {
                Console.Write($"{message}: ");
                optionRead = Console.ReadLine();

            } while (!int.TryParse(optionRead, out option) || option < min || option > max);

            return option;
        }

        public static char InputСhar()
        {
            char input;
            string readInput;
            do
            {
                Console.Write($"Введите символ: ");
                readInput = Console.ReadLine();
            } while (!char.TryParse(readInput, out input));

            return input;
        }
    }
}
