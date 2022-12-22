namespace AdventOfCode22.Day5;

public class Cargo
{
    private readonly List<string> _getStackById = new List<string>();

    public IList<string> GetStackById(int stackId)
    {
        return _getStackById;
    }
}