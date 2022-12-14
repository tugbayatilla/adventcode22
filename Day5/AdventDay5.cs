namespace AdventOfCode22.Day5;

public class CargoStack : Stack<string>
{
    public CargoStack(Stack<string> returnValue)
    {
        foreach (var val in returnValue)
        {
            Push(val);
        }
    }

    public Stack<string> ReturnValue { get; private set; }
}

public class Cargo
{
    public Cargo(Stack<string>[] returnValue)
    {
        ReturnValue = returnValue;
    }

    public Stack<string>[] ReturnValue { get; }

    public CargoStack GetStack(int stackId)
    {
        return new CargoStack(ReturnValue[stackId-1]);
    }
}

public class AdventDay5
{
    private Stack<string>[] _cargo = {new ()};

    public Cargo GetCargo()
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