public class Grid
{
    public Dictionary<int, char> Squares;
    public List<PartNumber> partNumbers;
    
    private int width;
    private int height;

    public Grid(IEnumerable<string> inputs)
    {
        height = inputs.Count();
        width = inputs.First().Length;

        var count = 0;

        Squares = new Dictionary<int, char>();

        foreach (var input in inputs.ToArray())
        {
            var charArray = input.ToCharArray();

            foreach (var c in charArray)
            {
                Squares.Add(count, c);
                count ++;
            }
        }
    }

    public IEnumerable<char> GetAdjacent(int position)
    {
        var chars = new List<char>();

        if (!InFirstColumn(position))
        {
            chars.Add(Squares[position - 1]);
        }

        if (!InFirstColumn(position) && !InFirstRow(position))
        {
            chars.Add(Squares[position - (width + 1)]);
        }

        if (!InFirstRow(position))
        {
            chars.Add(Squares[position - width]);
        }

        if (!InFirstRow(position) && !InLastColumn(position))
        {
            chars.Add(Squares[position - (width - 1)]);
        }

        if (!InLastColumn(position))
        {
            chars.Add(Squares[position + 1]);
        }

        if (!InLastColumn(position) && !InLastRow(position))
        {
            chars.Add(Squares[position + (width + 1)]);
        }

        if (!InLastRow(position))
        {
            chars.Add(Squares[position + width]);
        }

        if (!InLastRow(position) && !InFirstColumn(position))
        {
            chars.Add(Squares[position + (width - 1)]);
        }

        return chars;
    }

    private List<PartNumber> FindPartNumbers()
    {
        var sb = new List<char>();

        foreach (var kvp in Squares)
        {
            if (int.TryParse(kvp.Value, out val))
            {
                sb.Add(val);
            }
        }
    }

    private bool InFirstColumn(int position)
    {
        return position % width == 0;
    }

    private bool InFirstRow(int position)
    {
        return position < width;
    }

    private bool InLastColumn(int position)
    {
        return (position + 1) % width == 0;
    }

    private bool InLastRow(int position)
    {
        return position + width >= (height * width);
    }
}