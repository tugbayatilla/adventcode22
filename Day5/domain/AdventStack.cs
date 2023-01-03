namespace AdventOfCode22.Day5.domain;

public record AdventStack(int Id)
{
    private readonly Stack<string> _stack = new();

    public AdventStack AddCrates(params string[] crates)
    {
        crates.ToList().ForEach(_stack.Push);

        return this;
    }

    public bool IsEqual(string[] collection)
    {
        return _stack.ToArray().Reverse().SequenceEqual(collection);
    }

    public int Count => _stack.Count;

    public string RemoveCrate()
    {
        return _stack.Pop();
    }

    public string GetCrateByIndex(int index)
    {
        return _stack.ToArray()[index];
    }

    public string GetTopCrateOrEmpty()
    {
        return _stack.Any() ? _stack.Peek() : "";
    }
}