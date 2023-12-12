public class Grid
{
    private List<GridSquare> squares;
    
    private int width;
    private int height;

    public Grid(IEnumerable<string> inputs)
    {
        height = inputs.Count();
        width = inputs.First().Length;

        squares = new List<GridSquare>();

        for (var y = 0; y < height; y++)
        {
            var row = inputs.ToArray()[y].ToCharArray();

            for (var x = 0; x < width; x++)
            {
                squares.Add(new GridSquare(x, y, row[x]));
            }
        }
    }

	public List<char[]> GetValidStrings(Func<char, bool> itemCriterion, Func<char[], bool> adjacentCriterion)
	{
		var result = new List<char[]>();
		var placeholder = new List<char>();

		foreach (var square in squares)
		{
			if (itemCriterion(square.Value) && adjacentCriterion(GetAdjacentValues(square.Position).ToArray()))
			{
				placeholder.Add(square.Value);
			}
			else if (placeholder.Any())
			{
				var array = placeholder.ToArray();
				result.Add(array);
				placeholder.Clear();
			}
		}

		return result;
	}

    private IEnumerable<char>? GetAdjacentValues((int x, int y) position)
    {
        var values = new List<char>();

        var square = FindByPosition(position);

        if (square == null)
        {
            return null;
        }

        if (!square.InFirstColumn())
        {
            (int x, int y) pos = new(position.x - 1, position.y);
            var adj = FindByPosition(pos);
            values.Add(adj.Value);
        }

        if (!square.InFirstColumn() && !square.InFirstRow())
        {
			(int x, int y) pos = new(position.x - 1, position.y - 1);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

        if (!square.InFirstRow())
        {
			(int x, int y) pos = new(position.x, position.y - 1);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

		if (!square.InFirstRow() && !square.InLastColumn(width))
		{
			(int x, int y) pos = new(position.x + 1, position.y - 1);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

		if (!square.InLastColumn(width))
		{
			(int x, int y) pos = new(position.x + 1, position.y);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

		if (!square.InLastColumn(width) && !square.InLastRow(height))
		{
			(int x, int y) pos = new(position.x + 1, position.y + 1);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

		if (!square.InLastRow(height))
		{
			(int x, int y) pos = new(position.x, position.y + 1);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

		if (!square.InLastRow(height) && !square.InFirstColumn())
		{
			(int x, int y) pos = new(position.x - 1, position.y + 1);
			var adj = FindByPosition(pos);
			values.Add(adj.Value);
		}

		return values;
    }

    private GridSquare FindByPosition((int x, int y) position)
    {
        return squares.FirstOrDefault(s => s.Position == position);
    }

	private class GridSquare
	{
		public (int x, int y) Position { get; set; }

		public char Value { get; set; }

		public GridSquare(int x, int y, char value)
		{
			Position = new(x, y);
			Value = value;
		}

		public bool InFirstColumn()
		{
			return Position.x == 0;
		}

		public bool InFirstRow()
		{
			return Position.y == 0;
		}

		public bool InLastColumn(int width)
		{
			return Position.x >= width - 1;
		}

		public bool InLastRow(int height)
		{
			return Position.y >= height - 1;
		}
	}
}

