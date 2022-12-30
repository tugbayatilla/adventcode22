namespace AdventOfCode22.Day5;

public class AdventDay5
{
    private readonly Cargo _cargo = new Cargo();

    public Cargo GetCargo()
    {
        return _cargo;
    }

    public (Cargo, Movements) ParseLines(IEnumerable<string> lines)
        => (ParseCargo(lines), ParseMovements(lines));

    private Cargo ParseCargo(IEnumerable<string> lines)
    {
        var cargo = new Cargo();

        CreateStacksInCargo(lines, cargo);

        CreateCratesInStacksInCargo(lines, cargo);

        return cargo;
    }

    private void CreateCratesInStacksInCargo(IEnumerable<string> lines, Cargo cargo)
    {
        var cargoData = lines.TakeWhile(p => p != "");
        foreach (var line in cargoData.Reverse())
        {
            var fixedLine = FixEmptySpacesInALineToEaseSplitting(line);

            var crates = fixedLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (var index = 0; index < crates.Length; index++)
            {
                var crate = crates[index];

                AddCrateToStack(crate, cargo, index);
            }
        }
    }

    private void CreateStacksInCargo(IEnumerable<string> lines, Cargo cargo)
    {
        var numberOfStacks = FindTheNumberOfStacks(lines);

        for (int i = 1; i <= numberOfStacks; i++)
        {
            cargo.AddStack();
        }
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
                int.Parse(split[3]),
                int.Parse(split[5]),
                int.Parse(split[1]));
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
        var lastLine = lines.TakeWhile(p => p != "").LastOrDefault();
        var stackIdList = lastLine?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var numberOfStacks = stackIdList?.Length;
        return numberOfStacks ?? 0;
    }

    private static void AddCrateToStack(string crate, Cargo cargo, int index)
    {
        if (crate.Contains("[") && !crate.Contains("[-]"))
        {
            var crateName = GetCrateNameFromRawDefinition(crate);

            var stack = cargo.GetStackById(index + 1);
            stack.Add(crateName);
        }
    }

    private static string GetCrateNameFromRawDefinition(string crateDefinition)
    {
        return crateDefinition.Substring(1, 1);
    }

    public string AfterRearrangementCratesFromTopOfEachStacks(string filePath)
    {
        var cargo = Rearrange(filePath);

        var result = GetTopCratesFromEachStack(cargo);

        return result;
    }

    private static string GetTopCratesFromEachStack(Cargo cargo)
    {
        var result = "";
        for (var stackId = 1; stackId <= cargo.StackCount(); stackId++)
        {
            var stack = cargo.GetStackById(stackId);
            result += stack.LastOrDefault();
        }

        return result;
    }

    private Cargo Rearrange(string filePath)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        (Cargo cargo, Movements movements) = ParseLines(lines);

        foreach (var movement in movements)
        {
            cargo.Move(movement);
        }

        return cargo;
    }
}