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

}