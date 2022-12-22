namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly List<List<string>> _cargo = new(){new()};

    public IEnumerable<IEnumerable<string>> GetCargoState()
    {
        return _cargo;
    }

    public void AddCrateToStack(int stackId)
    {
        _cargo.Skip(stackId - 1).First().Add("");
    }
}