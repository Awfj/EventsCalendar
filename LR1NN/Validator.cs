namespace LR1NN
{
    public static class Validator
    {
        public const string DATE_PATTERN = @"^(0?[1-9]|[12]\d|3[01])\.(0?[1-9]|1[012])$";

        public static bool IsDateCorrect(string input)
        {
            string[] parts = input.Split('.');
            int day, month;

            if (parts.Length == 2 && int.TryParse(parts[0], out day) && int.TryParse(parts[1], out month))
            {
                if (DateTime.TryParse($"{day}/{month}/2023", out DateTime date))
                {
                    return date >= DateTime.Today;
                }
            }

            return false;
        }
    }
}
