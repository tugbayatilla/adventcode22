namespace AdventOfCode22.Day5;

public class Cargo
{
    private readonly List<string> _stackList = new();

    public IList<string> GetStackById(int stackId)
    {
        return _stackList;
    }

    public int AddStack()
    {
        return 1;
    }
}