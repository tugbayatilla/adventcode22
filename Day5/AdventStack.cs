using System.Collections;

namespace AdventOfCode22.Day5;

public class AdventStack
{
    private readonly Stack<string> _stack = new();
    public int Id { get; set; } = 1;
    
    public AdventStack AddCrates(params string[] crates)
    {
        crates.ToList().ForEach(_stack.Push);

        return this;
    }

    public bool SequenceEqual(string[] collection)
    {
        return _stack.ToArray().Reverse().SequenceEqual(collection);
    }

    public int Count => _stack.Count;

    public string RemoveCrates()
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