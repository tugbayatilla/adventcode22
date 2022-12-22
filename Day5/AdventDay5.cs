namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly Cargo _getCargo = new Cargo();

    public void AddCrateToStack(int stackId, string crateName)
    {
        _getCargo.GetStackById(stackId).Add(crateName);
    }

    public Cargo GetCargo()
    {
        return _getCargo;
    }
}