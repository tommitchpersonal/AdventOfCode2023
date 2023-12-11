namespace Shared.Input
{
    public class InputReader
    {
        public IEnumerable<string> Muliline(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
