namespace AdventOfCode22.Day3;

public class AdventDay3UnitTests
{
    [Fact]
    public void Test1()
    {
        AdventDay3 adventDay3 = new();
        
        Assert.Equal(0, adventDay3.SumOfPriorities());
    }
    
    [Fact]
    public void _002_identified_and_stored_item_lowercase_p_is_16_points()
    {
        AdventDay3 adventDay3 = new();

        adventDay3.IdentifyAndStorePriorityItem("p");
        
        Assert.Equal(16, adventDay3.SumOfPriorities());
    }
}