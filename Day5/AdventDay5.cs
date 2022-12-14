namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private Stack<string>[] _cargo = {new ()};

    public Stack<string>[] GetCurrentCargoState()
    {
        return _cargo;
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