public class Game
{
    public int Count;

    private IEnumerable<Round> rounds;

    private Dictionary<Colours, int> minimums;

    public Game(string input)
    {
        var gameAndRounds = input.Split(": ");
        var game = gameAndRounds.First();
        Count = int.Parse(game.Split(" ").Last());

        var roundsString = gameAndRounds.Last().Split("; ");

        rounds = roundsString.Select(rs => new Round(rs));

        minimums = SetMinimums();
    }

    public bool IsPossible(int maxBlue, int maxRed, int maxGreen)
    {
        return rounds.All(r => r.IsPossible(maxBlue, maxRed, maxGreen));
    }

    public int Power()
    {
        return minimums.Values.Aggregate((acc, val) => acc * val);
    }

    private Dictionary<Colours, int> SetMinimums()
    {
        var minimumRed = 0;
        var minimumBlue = 0;
        var minimumGreen = 0;

        foreach (var round in rounds)
        {
            var numberOfEach = round.GetNumberOfEachColour();

            if (numberOfEach.TryGetValue(Colours.red, out var reds) && reds > minimumRed)
            {
                minimumRed = reds;
            }

            if (numberOfEach.TryGetValue(Colours.blue, out var blues) && blues > minimumBlue)
            {
                minimumBlue = blues;
            }

            if (numberOfEach.TryGetValue(Colours.green, out var greens) && greens > minimumGreen)
            {
                minimumGreen = greens;
            }
        }

        return new Dictionary<Colours, int>()
        {
            {Colours.red, minimumRed},
            {Colours.blue, minimumBlue},
            {Colours.green, minimumGreen}
        };
    }
}