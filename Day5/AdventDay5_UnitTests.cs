namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    [Fact]
    public void _001_get_stacks_as_list_of_crates()
    {
        AdventDay5 adventDay5 = new();
        Assert.Empty(adventDay5.GetStacks());
    }

    [Fact]
    public void _002_register_crates_in_stacks_returns_3_stacks()
    {
        AdventDay5 adventDay5 = new();
        adventDay5.RegisterCratesInStacksWithStringDefinition("    [D]    ");
        Assert.Equal(3, adventDay5.GetStacks().Count());
    }

    [Fact]
    public void _003_parse_one_line_of_stack_definition()
    {
        AdventDay5 adventDay5 = new();
        var crates = adventDay5
            .ParseOneLineOfStackDefinition("    [D]    ")
            .ToArray();

        Assert.Equal("", crates[0]);
        Assert.Equal("[D]", crates[1]);
        Assert.Equal("", crates[2]);
    }

    [Fact]
    public void _004_register_crates_in_stacks_returns_valid_values()
    {
        AdventDay5 adventDay5 = new();
        adventDay5.RegisterCratesInStacksWithStringDefinition("    [D]    ");
        var stacks = adventDay5.GetStacks().ToArray();

        Assert.Equal("", stacks[0].First());
        Assert.Equal("[D]", stacks[1].First());
        Assert.Equal("", stacks[2].First());
    }

    [Fact]
    public void _005_register_crates_in_stacks_two_returns_valid_values()
    {
        AdventDay5 adventDay5 = new();
        adventDay5.RegisterCratesInStacksWithStringDefinition("    [D]    ");
        adventDay5.RegisterCratesInStacksWithStringDefinition("[N] [C]    ");

        var stacks = adventDay5.GetStacks().ToArray();
        Assert.True(Enumerable.SequenceEqual(new[] {"", "[N]"}, stacks[0]));
        Assert.True(Enumerable.SequenceEqual(new[] {"[D]", "[C]"}, stacks[1]));
        Assert.True(Enumerable.SequenceEqual(new[] {"", ""}, stacks[2]));
    }
}