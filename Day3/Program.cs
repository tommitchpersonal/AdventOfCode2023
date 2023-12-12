using Shared.Input;

public class Program
{
	public static void Main(string[] args)
	{
		var inputReader = new InputReader();
		var inputs = inputReader.Muliline("./Input/Input.txt");

		FirstPart(inputs.ToArray());

		Console.ReadLine();
	}

	private static void FirstPart(string[] inputs)
	{
		var grid = new Grid(inputs);
		var parts = grid.GetValidStrings(IsInt, HasAdjacentSymbol);

		var partCodes = new List<int>();

		foreach (var part in parts)
		{
			var partString = new string(part);
			var partCode = int.Parse(partString);	
			partCodes.Add(partCode);
		}

		var sum = partCodes.Sum();

		Console.WriteLine(sum);

	}

	private static bool IsInt(char c)
	{
		return int.TryParse(c.ToString(), out _);
	}

	private static bool HasAdjacentSymbol(char[] adjChars)
	{
		return adjChars.Any(c => c != '.' && !IsInt(c));
	}
}
