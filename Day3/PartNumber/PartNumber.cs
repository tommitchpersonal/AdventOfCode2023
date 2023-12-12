public class PartNumber
{
    public List<int> Positions;
    public int Value;

    public PartNumber(List<char> chars)
    {
        Positions = chars.Select(c => int.Parse(c));
    }
}