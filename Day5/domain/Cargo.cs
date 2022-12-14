using AdventOfCode22.Day5.strategies;

namespace AdventOfCode22.Day5.domain;

public class Cargo
{
    private readonly List<AdventStack> _stackList = new();

    public Cargo()
    {
        MoveStrategy = new StackMoveStrategy(this);
    }

    public IMoveStrategy MoveStrategy { get; private set; }

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
        MoveStrategy.Move(movement);
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

    public void ChangeStrategy<T>() where T: IMoveStrategy
    {
        ChangeStrategy(typeof(T));
    }

    public void ChangeStrategy(Type strategyType)
    {
        MoveStrategy = (IMoveStrategy)Activator.CreateInstance(strategyType, this);
    }
}