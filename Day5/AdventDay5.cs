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
        var cargo = new Cargo();
        var stack = cargo.AddStack();
        foreach (var line in lines.OrderByDescending(s => s))
        {
            if (line.Contains("["))
            {
                stack.Add(line.Substring(1,1));
            }
        }
        
        return (cargo, new Movements());
    }
}