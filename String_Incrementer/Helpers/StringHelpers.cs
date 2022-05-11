using System.Text.RegularExpressions;

namespace String_Incrementer.Helpers
{
    public static class StringHelpers
    {
        public static string IncreaseString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var numberAtTheEnd = GetNumberAtTheEndOfText(input);
            var isNumeric = int.TryParse(numberAtTheEnd, out int number);

            if (isNumeric)
            {
                var indexOfNumberAtTheEnd = input.LastIndexOf(numberAtTheEnd);
                var restTextOfInput = input[..indexOfNumberAtTheEnd];
                var nextNumber = number + 1;
                var numberTextOfInput = nextNumber.ToString().PadLeft(nextNumber.ToString().Length > number.ToString().Length ? numberAtTheEnd.Length + 1 : numberAtTheEnd.Length, '0');
                return $"{restTextOfInput}{numberTextOfInput}";
            }

            return $"{input}1";
        }

        private static string GetNumberAtTheEndOfText(string input)
        {
            return Regex.Match(input, @"\d+$", RegexOptions.RightToLeft).Value;
        }
    }
}
