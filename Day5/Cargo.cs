namespace AdventOfCode22.Day5;

public class Cargo
{
    private readonly List<List<string>> _stackList = new();

    public IList<string> GetStackById(int stackId)
    {
        return _stackList[stackId-1];
    }

    public int AddStack()
    {
        _stackList.Add(new List<string>());
        return _stackList.Count;
    }

    public int StackCount()
    {
        return _stackList.Count;
    }

    public void Move(int fromStackId, int toStackId, int numberOfCrates)
    {
        var fromStack = GetStackById(fromStackId);
        var lastCrateFromStack = fromStack.Last();
        fromStack.Remove(lastCrateFromStack);
        
        GetStackById(toStackId).Add(lastCrateFromStack);
    }
}