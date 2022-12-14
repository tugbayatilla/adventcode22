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

    public void AddCrate(string crate)
    {
        Push(crate);
    }
}

public class Cargo
{
    private readonly List<CargoStack> _stacks = new();

    public Cargo(Stack<string>[] returnValue)
    {
        ReturnValue = returnValue;
        _stacks.Add(new CargoStack(new Stack<string>()));
        _stacks.Add(new CargoStack(new Stack<string>()));
    }

    public Stack<string>[] ReturnValue { get; }

    public CargoStack GetStack(int stackId)
    {
        return _stacks.Skip(stackId - 1).First();
    }
}

public class AdventDay5
{
    private readonly Cargo _myCargo = new(new CargoStack[] { });

    public Cargo GetCargo()
    {
        return _myCargo;
    }

    public void AddCrateToStack(int stackId, string crate)
    {
        _myCargo.GetStack(stackId).AddCrate(crate);
    }
}