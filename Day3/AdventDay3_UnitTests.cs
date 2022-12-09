namespace AdventOfCode22.Day3;

public class AdventDay3UnitTests
{
    [Fact]
    public void Test1()
    {
        AdventDay3 adventDay3 = new();
        
        Assert.Equal(0, adventDay3.SumOfPriorities());
    }
}