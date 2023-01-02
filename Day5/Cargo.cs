namespace AdventOfCode22.Day5;

public class Cargo
{
    private readonly List<AdventStack> _stackList = new();
    public StackMoveStrategy MoveStrategy { get; set; } = new ();

    public AdventStack GetStackById(int stackId)
    {
        return _stackList.First(p => p.Id == stackId);
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
            toStack.AddCrates(fromStack.RemoveCrate());
        }
    }

    public AdventStack CreateStackById(int stackId)
    {
        var stack = new AdventStack(stackId);
        
        _stackList.Add(stack);
        
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
                if (stack.Count > i)
                {
                    line += $" [{stack.GetCrateByIndex(i)}] ";
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