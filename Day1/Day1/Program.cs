using Shared.Input;

namespace Day1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var inputs = inputReader.Muliline("./input/input.txt");

            FirstPart(inputs);
            SecondPart(inputs);
        }

        private static void FirstPart(IEnumerable<string> inputs)
        {
            var firstAndLastIntegers = InputParser.FindFirstAndLastIntegers(inputs);

            CalculateAnswerAndReport(firstAndLastIntegers, 'a');
        }

        private static void SecondPart(IEnumerable<string> inputs) 
        {
            var firstAndLastIntegers = InputParser.FindFirstAndLastIntegers(inputs, true);

            CalculateAnswerAndReport(firstAndLastIntegers, 'b');
        }

        private static void CalculateAnswerAndReport(IEnumerable<(int first, int last)> firstAndLastIntegers, char part)
        {
            var values = NumberBuilder.BuildTwoDigitNumbers(firstAndLastIntegers);

            var answer = values.Sum();

            Console.WriteLine($"Part {part}: {answer}");
        }
    }
}