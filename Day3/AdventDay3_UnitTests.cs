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
    
    [Fact]
    public void _003_identified_and_stored_two_items_lowercase_p_and_uppercase_L_are_54_points()
    {
        AdventDay3 adventDay3 = new();

        adventDay3.IdentifyAndStorePriorityItem("p");
        adventDay3.IdentifyAndStorePriorityItem("L");
        
        Assert.Equal(16+38, adventDay3.SumOfPriorities());
    }
    
    [Theory]
    [InlineData("p", 16)]
    [InlineData("L", 38)]
    [InlineData("pL", 54)]
    public void _004_identified_and_stored_items_and_calculate_sum_of_priorities(string priorityItems, int expectedSumOfPriority)
    {
        AdventDay3 adventDay3 = new();

        foreach (var priorityItem in priorityItems)
        {
            adventDay3.IdentifyAndStorePriorityItem(priorityItem.ToString());
        }

        Assert.Equal(expectedSumOfPriority, adventDay3.SumOfPriorities());
    }
}