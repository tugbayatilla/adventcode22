namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly List<List<string>> _stack = new();

    public IEnumerable<IEnumerable<string>> GetStacks()
    {
        return _stack;
    }

    public void RegisterCratesInStacksWithStringDefinition(string stackLineInfo)
    {
        _stack.Add(null);
        _stack.Add(null);
        _stack.Add(null);
    }
}