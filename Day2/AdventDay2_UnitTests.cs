namespace AdventOfCode22.Day2;

public class AdventDay2UnitTests
{
    
    [Fact]
    public void _001_Day2_exist()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.NotNull(adventDay2);
    }
    
    [Fact]
    public void _002_opponents_and_i_say_nothing_then_i_get_zero_point()
    {
        AdventDay2 adventDay2 = new();
        
        Assert.Equal(0, adventDay2.Calculate("",""));
    }
    
    
}

public class AdventDay2
{
    public int Calculate(string opponentSelection, string mySelection)
    {
        return 0;
    }
}