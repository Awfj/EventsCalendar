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
    }
}
