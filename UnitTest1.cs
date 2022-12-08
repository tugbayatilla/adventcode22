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
    
    [Fact]
    public void Add_Calories_To_An_Elf_returns_the_calories()
    {
        AdventDay1 adventDay1 = new();
        adventDay1.AddCalories(100);
        
        Assert.Equal(100, adventDay1.GetMostCalories());
    }
}

public class AdventDay1
{
    // 2
    private int _totalCalories;

    public int GetMostCalories()
    {
        return _totalCalories; // 3
    }

    public void AddCalories(int calories)
    {
        // 1
        _totalCalories = calories;
    }
}