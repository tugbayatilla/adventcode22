namespace AdventOfCode22.Day5;

public class Cargo
{
    private readonly List<List<string>> _stackList = new();

    public IList<string> GetStackById(int stackId)
    {
        return _stackList[stackId - 1];
    }

    public int StackCount()
    {
        return _stackList.Count;
    }

    public void Move(int fromStackId, int toStackId, int numberOfCrates)
    {
        var fromStack = GetStackById(fromStackId);
        var movingCount = fromStack.Count < numberOfCrates ? fromStack.Count : numberOfCrates;
        for (var i = 0; i < movingCount; i++)
        {
            var lastCrateFromStack = fromStack.Last();
            fromStack.Remove(lastCrateFromStack);

            GetStackById(toStackId).Add(lastCrateFromStack);
        }
    }

    public IList<string> AddStack(params string[] crates)
    {
        _stackList.Add(new List<string>());
        var stack = GetStackById(_stackList.Count);
        crates.ToList().ForEach(p => stack.Add(p));

        return stack;
    }
}