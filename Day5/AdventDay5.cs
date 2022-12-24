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
        if (lines.Any())
        {
            var lastLine = lines.Last();
            var stackIdList = lastLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var numberOfStacks = stackIdList.Length;

            for (int i = 1; i <= numberOfStacks; i++)
            {
                cargo.AddStack();
                foreach (var line in lines.OrderByDescending(s => s))
                {
                    if (line.Contains("["))
                    {
                        var stack = cargo.GetStackById(i);
                        stack.Add(line.Substring(1, 1));
                    }
                }
            }
        }


        return (cargo, new Movements());
    }
}