namespace LR1NN
{
    public static class Validator
    {
        public static bool IsDateCorrect(string input)
        {
            if (DateTime.TryParse(input, out DateTime date))
            {
                return date >= DateTime.Today;
            }

            return false;
        }
    }
}
