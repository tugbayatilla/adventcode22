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
    
    public IEnumerable<string> ParseOneLineOfStackDefinition(string stackLineInfo)
    {
        // fill empty spaces with meaningful data
        var reArrangedInfo = stackLineInfo.Replace("    ", " [-] ");
        // remove white spaces from at the start and end
        reArrangedInfo = reArrangedInfo.Trim();
        // split data to an array
        var crates = reArrangedInfo.Split(" ");
        for (var i = 0; i < crates.Length; i++)
        {
            // remove temp definition
            if (crates[i] == "[-]")
            {
                crates[i] = "";
            }
        }
        return crates;
    }
}