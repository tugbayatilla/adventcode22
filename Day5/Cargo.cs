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

    public void Move(Movement movement)
    {
        var fromStack = GetStackById(movement.From);
        var toStack = GetStackById(movement.To);
        
        var movingCount = fromStack.Count < movement.Move ? fromStack.Count : movement.Move;
        
        for (var i = 0; i < movingCount; i++)
        {
            var lastCrateFromStack = fromStack.Last();
            fromStack.Remove(lastCrateFromStack);

            toStack.Add(lastCrateFromStack);
        }
    }

    public IList<string> AddStack(params string[] crates)
    {
        _stackList.Add(new List<string>());
        var stack = GetStackById(_stackList.Count);
        crates.ToList().ForEach(p => stack.Add(p));

        return stack;
    }

    public int CrateCount()
    {
        return _stackList.Select(p => p.Count).Sum();
    }

    public string Draw()
    {
        var line = "";
        var maxCount = _stackList.Select(p => p.Count).Max();
        for (var i = maxCount; i >= 0; --i)
        {
            foreach (var stack in _stackList)
            {
                if(stack.Count > i)
                {
                    line += $" [{stack[i]}] ";
                }
                else
                {
                    line += $"     ";
                }
            }

            line += Environment.NewLine;
        }

        for (int i = 1; i <= _stackList.Count; i++)
        {
            line += $"  {i}  ";
        }
        line += Environment.NewLine;
        
        return line;
    }
}