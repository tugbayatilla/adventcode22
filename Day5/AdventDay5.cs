namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly Stack<string>[] _cargo = {new ()};

    public Stack<string>[] GetCurrentCargoState()
    {
        return _cargo;
    }

    public void AddCrateToStack(int stackId, string crate)
    {
        _cargo[stackId - 1].Push(crate);
    }
}