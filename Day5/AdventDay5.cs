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
        var cargo = ParseCargo(lines);

        var movements = ParseMovements(lines);

        return (cargo, movements);
    }

    private Cargo ParseCargo(IEnumerable<string> lines)
    {
        var cargo = new Cargo();
        var numberOfStacks = FindTheNumberOfStacks(lines);

        for (int i = 1; i <= numberOfStacks; i++)
        {
            cargo.AddStack();
        }
        
        var cargoData = lines.TakeWhile(p => p != "");
        foreach (var line in cargoData.Reverse())
        {
            var fixedLine = FixEmptySpacesInALineToEaseSplitting(line);

            var crates = fixedLine.Split(' ');
            for (var index = 0; index < crates.Length; index++)
            {
                var crate = crates[index];

                AddCrateToStack(crate, cargo, index);
            }
        }

        return cargo;
    }

    private static Movements ParseMovements(IEnumerable<string> lines)
    {
        var movements = new Movements();

        var movementData = lines.SkipWhile(p => p != "").Skip(1);
        foreach (var data in movementData)
        {
            var split = data.Split(" ");

            if (split.Length != 6) continue;

            var movement = new Movement(
                int.Parse(split[1]),
                int.Parse(split[3]),
                int.Parse(split[5]));
            movements.Add(movement);
        }

        return movements;
    }

    private string FixEmptySpacesInALineToEaseSplitting(string line)
    {
        var emptySlotDefinitionInStack = "    ";
        var emptySlotNewDefinitionInStack = " [-] ";

        var fixedLine = line.Replace(emptySlotDefinitionInStack, emptySlotNewDefinitionInStack);
        var trimmedFixLine = fixedLine.Trim();
        return trimmedFixLine;
    }

    private int FindTheNumberOfStacks(IEnumerable<string> lines)
    {
        var lastLine = lines.LastOrDefault();
        var stackIdList = lastLine?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var numberOfStacks = stackIdList?.Length;
        return numberOfStacks ?? 0;
    }

    private static void AddCrateToStack(string crate, Cargo cargo, int index)
    {
        if (crate.Contains("[") && !crate.Contains("[-]"))
        {
            var crateName = GetCrateNameFromRawDefinition(crate);
            if (!string.IsNullOrEmpty(crateName))
            {
                var stack = cargo.GetStackById(index + 1);
                stack.Add(crateName);
            }
        }
    }

    private static string GetCrateNameFromRawDefinition(string crateDefinition)
    {
        return crateDefinition.Substring(1, 1);
    }
}