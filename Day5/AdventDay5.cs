namespace AdventOfCode22.Day5;

public class Cargo
{
    public Cargo(Stack<string>[] returnValue)
    {
        ReturnValue = returnValue;
    }

    public Stack<string>[] ReturnValue { get; }

    public Stack<string> GetStack(int stackId)
    {
        return ReturnValue[stackId];
    }
}

public class AdventDay5
{
    private Stack<string>[] _cargo = {new ()};

    public Cargo GetCurrentCargoState()
    {
        return new Cargo(_cargo);
    }

    public void AddCrateToStack(int stackId, string crate)
    {
        if (_cargo.Length < stackId)
        {
            Array.Resize(ref _cargo, stackId);
        }

        _cargo[stackId - 1] ??= new Stack<string>();
        
        _cargo[stackId - 1].Push(crate);
    }
}