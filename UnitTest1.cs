namespace AdventOfCode22;

public class UnitTest1
{
    [Fact]
    public void Day_Exist()
    {
        AdventDay1 adventDay1 = new();
        
        Assert.NotNull(adventDay1);
    }
    
    [Fact]
    public void Return_MostCalories_Exist()
    {
        AdventDay1 adventDay1 = new();
        
        Assert.Equal(0, adventDay1.GetMostCalories());
    }
}

public class AdventDay1
{
    public int GetMostCalories()
    {
        return 0;
    }
}