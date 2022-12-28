namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly Cargo _cargo = new Cargo();

    public Cargo GetCargo()
    {
        return _cargo;
    }

    public (Cargo, Movements) ParseLines(IEnumerable<string> lines)
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
            }
            
            foreach (var line in lines.OrderByDescending(s=>s))
            {
                var fixedLine = line.Replace("    ", " [-] ");
                var trimmedFixLine = fixedLine.Trim();

                var crates = trimmedFixLine.Split(' ');
                for (var index = 0; index < crates.Length; index++)
                {
                    var crate = crates[index];
                    if (crate.Contains("[") && !crate.Contains("[-]"))
                    {
                        var crateName = GetCrateNameFromRawDefinition(crate);
                        if (!string.IsNullOrEmpty(crateName))
                        {
                            var stack = cargo.GetStackById(index+1);
                            stack.Add(crateName);
                        }
                    }
                }
            }
        }


        return (cargo, new Movements());
    }

    private static string GetCrateNameFromRawDefinition(string crateDefinition)
    {
        return crateDefinition.Substring(1, 1);
    }
}