public class Round
{
    private int blue;
    private int red;
    private int green;

    public Round(string input)
    {
        var pairs = input.Split(", ");

        foreach (var pair in pairs)
        {
            var values = pair.Split(' ');
            Enum.TryParse(typeof(Colours), values[1], out var colour);

            switch (colour)
            {
                case Colours.red:
                    red = int.Parse(values[0]);
                    break;
                case Colours.blue:
                    blue = int.Parse(values[0]);
                    break;
                case Colours.green:
                    green = int.Parse(values[0]);
                    break;
            }
            
        }
    }

    public bool IsPossible(int maxBlue, int maxRed, int maxGreen)
    {
        System.Console.WriteLine($"Blue: {blue}, Red: {red}, Greem: {green}");
        return blue <= maxBlue && red <= maxRed && green <= maxGreen;
    }

    public Dictionary<Colours, int> GetNumberOfEachColour()
    {
        return new Dictionary<Colours, int>()
        {
            {Colours.red, red},
            {Colours.blue, blue},
            {Colours.green, green}
        };
    }
}
