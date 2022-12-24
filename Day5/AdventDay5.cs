namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly Cargo _cargo = new Cargo();
    
    public Cargo GetCargo()
    {
        return _cargo;
    }

    public (Cargo, Movements) ParseFile(IEnumerable<string> lines)
    {
        return (new Cargo(), new Movements());
    }
}