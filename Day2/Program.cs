using Shared.Input;

namespace Day2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var inputs = inputReader.Muliline("./Input/Input.txt");

            FirstPart(inputs);
            SecondPart(inputs);
        }

        private static void FirstPart(IEnumerable<string> inputs)
        {
            var games = new List<Game>();

            foreach (var input in inputs)
            {
                games.Add(new Game(input));
            }

            var possibleGames = games.Where(g => g.IsPossible(14, 12, 13));

            System.Console.WriteLine(possibleGames.Sum(pg => pg.Count));
        }

        private static void SecondPart(IEnumerable<string> inputs)
        {
            var games = new List<Game>();

            foreach (var input in inputs)
            {
                games.Add(new Game(input));
            }

            System.Console.WriteLine(games.Sum(g => g.Power()));
        }
    }
}