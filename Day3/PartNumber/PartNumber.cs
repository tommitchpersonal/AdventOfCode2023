public class PartNumber
{
    public List<int> Positions;
    public int Value;

    public PartNumber(List<char> chars)
    {
        foreach (var c in chars)
        {
            Positions.Add(int.Parse(c.ToString()));
        }

        Value = int.Parse(chars.ToString());
    }
}