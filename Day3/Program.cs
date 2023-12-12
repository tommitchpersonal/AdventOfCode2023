using Shared.Input;

public class Program
{
	public static void Main(string[] args)
	{
		var inputReader = new InputReader();
		var inputs = inputReader.Muliline("./Input/Input.txt");

		FirstPart(inputs.ToArray());
	}

	private static void FirstPart(string[] inputs)
	{
		var grid = new Grid(inputs);
		var parts = grid.GetValidStrings(IsInt, HasAdjacentSymbol);
		
		foreach (var part in parts)
		{
			Console.WriteLine(GetInt(part));
		}
	}

	private static bool IsInt(char c)
	{
		return int.TryParse(c.ToString(), out _);
	}

	private static int GetInt(char[] chars)
	{
		return int.Parse(chars.ToString());
	}

	private static bool HasAdjacentSymbol(char[] adjChars)
	{
		return adjChars.Any(c => c != '.' && !IsInt(c));
	}
}
