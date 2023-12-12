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

		foreach (var square in squares)
		{
			var adjacentSquares = GetAdjacentSquares(square);
			square.SetAdjacentSquares(adjacentSquares.ToList());
		}
    }

	public List<char[]> GetValidStrings(Func<char, bool> itemCriterion, Func<char[], bool> adjacentCriterion)
	{
		var result = new List<char[]>();
		var placeholder = new List<GridSquare>();

		foreach (var square in squares)
		{
			if (square.ValidValue(itemCriterion))
			{
				placeholder.Add(square);
			}
			else if (placeholder.Any(p => p.ValidAdjacent(adjacentCriterion)))
			{
				result.Add(placeholder.Select(p => p.Value).ToArray());
				placeholder.Clear();
			}
			else
			{
				placeholder.Clear();
			}
		}

		return result;
	}

    private IEnumerable<GridSquare>? GetAdjacentSquares(GridSquare square)
    {
        var adjacentSquares = new List<GridSquare>();

        var position = square.Position;

        if (square == null)
        {
            return null;
        }

        if (!square.InFirstColumn())
        {
            (int x, int y) pos = new(position.x - 1, position.y);
            var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
        }

        if (!square.InFirstColumn() && !square.InFirstRow())
        {
			(int x, int y) pos = new(position.x - 1, position.y - 1);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

        if (!square.InFirstRow())
        {
			(int x, int y) pos = new(position.x, position.y - 1);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

		if (!square.InFirstRow() && !square.InLastColumn(width))
		{
			(int x, int y) pos = new(position.x + 1, position.y - 1);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

		if (!square.InLastColumn(width))
		{
			(int x, int y) pos = new(position.x + 1, position.y);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

		if (!square.InLastColumn(width) && !square.InLastRow(height))
		{
			(int x, int y) pos = new(position.x + 1, position.y + 1);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

		if (!square.InLastRow(height))
		{
			(int x, int y) pos = new(position.x, position.y + 1);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

		if (!square.InLastRow(height) && !square.InFirstColumn())
		{
			(int x, int y) pos = new(position.x - 1, position.y + 1);
			var adj = FindByPosition(pos);
			adjacentSquares.Add(adj);
		}

		return adjacentSquares;
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

		private List<GridSquare>? adjacentSquares;

		public void SetAdjacentSquares(List<GridSquare> adj)
		{
			adjacentSquares = adj;
		}

		public bool ValidValue(Func<char, bool> criterion)
		{
			return criterion(Value);
		}

		public bool ValidAdjacent(Func<char[], bool> criterion)
		{
			var adjacentCharacters = adjacentSquares.Select(s => s.Value).ToList();
			return criterion(adjacentCharacters.ToArray());
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

