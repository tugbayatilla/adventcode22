namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    
    [Fact]
    public void _001_get_stacks_as_list_of_crates()
    {
        AdventDay5 adventDay5 = new();
        Assert.Empty(adventDay5.GetStacks());
    }

}