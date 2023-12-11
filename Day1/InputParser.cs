using System.Text;

namespace Day1
{
    public static class InputParser
    {
        private static string[] validWords = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }; // Keep this order
        
        public static IEnumerable<(int first, int second)> FindFirstAndLastIntegers(IEnumerable<string> inputStrings, bool includeAsWord = false)
        {
            var output = new List<(int first, int second)>();

            foreach (var inputString in inputStrings)
            {
                var integers = GetIntegers(inputString, includeAsWord);

                if (integers.Count() == 1)
                {
                    output.Add((integers.First(), integers.First()));
                }
                else if (integers.Count() > 1)
                {
                    output.Add((integers.First(), integers.Last()));
                }
                else
                {
                    output.Add((0, 0));
                }
            }

            return output;
        }

        private static IEnumerable<int> GetIntegers(string input, bool includeAsWord)
        {
            if (includeAsWord)
            {
                for (var i = 0; i < validWords.Count(); i++)
                {
                    input = input.Replace(validWords[i], $"{validWords[i].First()}{i + 1}{validWords[i].Last()}");
                }
            }

            var chars = input.Select(x => x.ToString()).ToArray();
            var output = new List<int>();

            foreach (string c in chars)
            {
                if (int.TryParse(c.ToString(), out var i))
                {
                    output.Add(i);
                }
            }

            return output;
        }
    }
}
