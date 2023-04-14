namespace LR1NN
{
    public class Validator
    {
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
